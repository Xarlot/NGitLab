using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NGitLab.Impl {
    [DataContract]
    internal class JsonError {
#pragma warning disable 649
        [DataMember(Name = "message")]
        public string Message;
#pragma warning restore 649
    }

    public class HttpRequestor {
        readonly MethodType method; // Default to GET requests
        readonly Api root;
        object _data;

        public HttpRequestor(Api root, MethodType method) {
            this.root = root;
            this.method = method;
        }

        public HttpRequestor With(object data) {
            _data = data;
            return this;
        }

        public T To<T>(string tailApiUrl) {
            var result = default(T);
            string json = null;
            Stream(tailApiUrl, s =>
            {
                string data;
                using(var reader = new StreamReader(s))
                    data = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<T>(data);
                json = data;
            });
            return result;
        }


        public async Task<T> ToAsync<T>(string tailApiUrl)
        {
            var result = default(T);
            string json = null;
            await StreamAsync(tailApiUrl, async s => {
                string data;
                using(var reader = new StreamReader(s))
                    data = await reader.ReadToEndAsync();
                result = JsonConvert.DeserializeObject<T>(data);
                json = data;
            });
            return result;
        }


        public void Stream(string tailApiUrl, Action<Stream> parser) {
            HttpWebRequest req =(HttpWebRequest) SetupConnection(root.GetApiUrl(tailApiUrl));
            req.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (Object obj, X509Certificate X509certificate, X509Chain chain, System.Net.Security.SslPolicyErrors errors)
            {
                return true;
            };
           
           req.ServerCertificateValidationCallback = delegate (Object obj, X509Certificate X509certificate, X509Chain chain, System.Net.Security.SslPolicyErrors errors)
            {
                return true;
            };
           
            if (HasOutput())
                SubmitData(req);
            else if (method == MethodType.Put)
                req.Headers.Add("Content-Length", "0");
          

            try {
                using (var response = req.GetResponse()) {
                    using (var stream = response.GetResponseStream()) {
                        parser(stream);
                    }
                }
            }
            catch (WebException wex) {
                if (wex.Response != null)
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            var jsonString = reader.ReadToEnd();
                            if (!string.IsNullOrEmpty(jsonString))
                            {
                                JObject jsonerr = JsonConvert.DeserializeObject<JObject>(jsonString);
                                var messaage = jsonerr.GetValue("message");
                                if (messaage != null)
                                {
                                    if (messaage.Type == JTokenType.String && !messaage.Children().Any())
                                    {
                                        throw new Exception($"{errorResponse.StatusCode} {messaage}");
                                    }
                                    else if (messaage.Type == JTokenType.Object)
                                    {
                                        string errs = "";
                                        foreach (var item in messaage.Children())
                                        {
                                            if (item.Type == JTokenType.Property)
                                            {
                                                JProperty jProperty = item as JProperty;
                                                errs += $" {jProperty.Name } {jProperty.Value}";
                                            }
                                        }
                                        throw new Exception($"{errorResponse.StatusCode} {errs}");
                                    }
                                    else
                                    {
                                        throw new Exception($"{errorResponse.StatusCode} {jsonString}");
                                    }
                                }
                                else
                                {
                                    var error = jsonerr.GetValue("error");
                                    throw new Exception(error + " " + jsonerr.GetValue("error_description"));
                                }
                            }

                        }
                    }
                throw wex;
            }
        }

        public async Task StreamAsync(string tailApiUrl, Func<Stream, Task> parser)
        {
            var req = SetupConnection(root.GetApiUrl(tailApiUrl));

            if (HasOutput())
                SubmitData(req);
            else if (method == MethodType.Put)
                req.Headers.Add("Content-Length", "0");

            try
            {
                using (var response = await req.GetResponseAsync())
                {
                    using (var stream = response.GetResponseStream())
                    {
                       await parser(stream);
                    }
                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            var jsonString = reader.ReadToEnd();
                            if (!string.IsNullOrEmpty(jsonString))
                            {
                                JObject jsonerr = JsonConvert.DeserializeObject<JObject>(jsonString);
                                var messaage = jsonerr.GetValue("message");
                                if (messaage != null)
                                {
                                    if (messaage.Type == JTokenType.String && !messaage.Children().Any())
                                    {
                                        throw new Exception($"{errorResponse.StatusCode} {messaage}");
                                    }
                                    else if (messaage.Type == JTokenType.Object)
                                    {
                                        string errs = "";
                                        foreach (var item in messaage.Children())
                                        {
                                            if (item.Type == JTokenType.Property)
                                            {
                                                JProperty jProperty = item as JProperty;
                                                errs += $" {jProperty.Name } {jProperty.Value}";
                                            }
                                        }
                                        throw new Exception($"{errorResponse.StatusCode} {errs}");
                                    }
                                    else
                                    {
                                        throw new Exception($"{errorResponse.StatusCode} {jsonString}");
                                    }
                                }
                                else
                                {
                                    var error = jsonerr.GetValue("error");
                                    throw new Exception(error + " " + jsonerr.GetValue("error_description"));
                                }
                            }

                        }
                    }
                throw wex;
            }
        }


        public IEnumerable<T> GetAll<T>(string tailUrl) {
            return new Enumerable<T>(root.ApiToken, root.GetApiUrl(tailUrl), root._ApiVersion);
        }

        void SubmitData(WebRequest request) {
            request.ContentType = "application/json";

            using (var writer = new StreamWriter(request.GetRequestStream())) {
                var data = JsonConvert.SerializeObject(_data, new JsonSerializerSettings {
                    NullValueHandling = NullValueHandling.Ignore
                });
                writer.Write(data);
                writer.Flush();
            }
        }

        bool HasOutput() {
            return method == MethodType.Post || method == MethodType.Put || method == MethodType.Delete && _data != null;
        }

        WebRequest SetupConnection(Uri url) {
            return SetupConnection(url, method, root.ApiToken,root._ApiVersion);
        }

      
       
        static WebRequest SetupConnection(Uri url, MethodType methodType, string privateToken, ApiVersion apiVersion) {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = methodType.ToString().ToUpperInvariant();
            request.Headers.Add("Accept-Encoding", "gzip");
            request.AutomaticDecompression = DecompressionMethods.GZip;
            if (apiVersion.UsesOauth())
            {
                request.Headers["Authorization"] = "Bearer " + privateToken;
            }
            else
            {
                request.Headers["PRIVATE-TOKEN"] = privateToken;
            }
          
#if DEBUG
            request.Proxy.Credentials = CredentialCache.DefaultCredentials;

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
#endif

            return request;
        }

        class Enumerable<T> : IEnumerable<T> {
            readonly string apiToken;
            readonly Uri startUrl;
           readonly ApiVersion _apiVersion;
            public Enumerable(string apiToken, Uri startUrl, ApiVersion _ApiVersion) {
                this.apiToken = apiToken;
                this.startUrl = startUrl;
                _apiVersion = _ApiVersion;
            }

            public IEnumerator<T> GetEnumerator() {
                return new Enumerator(apiToken, startUrl, _apiVersion);
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return GetEnumerator();
            }

            class Enumerator : IEnumerator<T> {
                readonly string apiToken;
                readonly ApiVersion _apiVersion;
                private int port;
                readonly List<T> buffer = new List<T>();
                Uri nextUrlToLoad;

                public Enumerator(string apiToken, Uri startUrl, ApiVersion _ApiVersion) {
                    this.apiToken = apiToken;
                    nextUrlToLoad = startUrl;
                    _apiVersion = _ApiVersion;
                    port = nextUrlToLoad.Port;
                }

                public void Dispose() {
                }

                public bool MoveNext() {
                    if (buffer.Count == 0) {
                        if (nextUrlToLoad == null)
                            return false;
                        if (nextUrlToLoad.Port != port)  // 修正端口
                        {
                            var ub = new UriBuilder(nextUrlToLoad);
                            ub.Port = port;
                            nextUrlToLoad = ub.Uri;
                        }
                        var request = SetupConnection(nextUrlToLoad, MethodType.Get, apiToken, _apiVersion);
                        if (_apiVersion.UsesOauth())
                        {
                            request.Headers["Authorization"] = "Bearer " + apiToken;
                        }
                        else
                        {
                            request.Headers["PRIVATE-TOKEN"] = apiToken;
                        }

                        using (var response = request.GetResponse()) {
                            // <http://localhost:1080/api/v3/projects?page=2&per_page=0>; rel="next", <http://localhost:1080/api/v3/projects?page=1&per_page=0>; rel="first", <http://localhost:1080/api/v3/projects?page=2&per_page=0>; rel="last"
                            var link = response.Headers["Link"];

                            string[] nextLink = null;
                            if (string.IsNullOrEmpty(link) == false)
                                nextLink = link.Split(',')
                                    .Select(l => l.Split(';'))
                                    .FirstOrDefault(pair => pair[1].Contains("next"));

                            if (nextLink != null)
                                nextUrlToLoad = new Uri(nextLink[0].Trim('<', '>', ' '));
                            else
                                nextUrlToLoad = null;

                            var stream = response.GetResponseStream();
                            var data = new StreamReader(stream).ReadToEnd();
                            buffer.AddRange(JsonConvert.DeserializeObject<T[]>(data));
                        }

                        return buffer.Count > 0;
                    }

                    if (buffer.Count > 0) {
                        buffer.RemoveAt(0);
                        return buffer.Count > 0 ? true : MoveNext();
                    }

                    return false;
                }

                public void Reset() {
                    throw new NotImplementedException();
                }

                public T Current => buffer[0];

                object IEnumerator.Current => Current;
            }
        }
    }
}