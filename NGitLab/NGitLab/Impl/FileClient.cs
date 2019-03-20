using Newtonsoft.Json;
using NGitLab.Models;
using System.IO;

namespace NGitLab.Impl {
    public class FileClient : IFilesClient {
        readonly Api api;
        readonly string repoPath;

        public FileClient(Api api, string repoPath) {
            this.api = api;
            this.repoPath = repoPath;
        }

        private string GetFilePath(string filePath, string branch)
        {
            filePath = System.Web.HttpUtility.UrlEncode(filePath);

            return api._ApiVersion.IsV4()
                ? $"/files/{filePath}?ref={branch}"
                : $"/files?file_path={filePath}&ref={branch}";
        }

        public void Create(FileUpsert file) {
            api.Post().With(file).Stream(repoPath + GetFilePath(file.Path, file.Branch), s => { });
        }

        public void Update(FileUpsert file) {
            api.Put().With(file).Stream(repoPath + GetFilePath(file.Path, file.Branch), s => { });
        }

        public void Delete(FileDelete file) {
            api.Delete().With(file).Stream(repoPath + GetFilePath(file.Path, file.Branch), s => { });
        }

        public FileData Get(string filePath, string branch = "", System.Action<System.IO.Stream> parser = null)
        {
            FileData fileData = null;

            if (branch == "")
                branch = "master";

            filePath = $"{GetFilePath(filePath, branch)}";

            api.Get().Stream(repoPath + filePath, s =>
            {
                if (parser != null)
                    parser(s);

                StreamReader sr = new StreamReader(s);
                var content = sr.ReadToEnd();
                fileData = JsonConvert.DeserializeObject<FileData>(content);
            });
            return fileData;
        }
    }
}