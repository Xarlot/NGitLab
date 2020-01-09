using NGitLab.Impl;
using NGitLab.Models;
using System.Web;

namespace NGitLab {
    public class GitLabClient {
        readonly Api api;

        public readonly INamespaceClient Groups;
        public readonly IIssueClient Issues;
        public readonly IProjectClient Projects;
        public readonly IUserClient Users;
        public readonly IDeployKeyClient DeployKeys;

        public string ApiToken => api.ApiToken;
        GitLabClient(string hostUrl, string apiToken) : this(hostUrl, apiToken, ApiVersion.V4)
        {
        }
        GitLabClient(string hostUrl, string apiToken, ApiVersion apiVersion)
        {
            api = new Api(hostUrl, apiToken);
            api._ApiVersion = apiVersion;
            Users = new UserClient(api);
            Projects = new ProjectClient(api);
            Issues = new IssueClient(api);
            Groups = new NamespaceClient(api);
            DeployKeys = new DeployKeyClient(api);
        }
        public static GitLabClient Connect(string hostUrl, string username, string password)
        {
            return Connect(hostUrl, username, password, ApiVersion.V4_Oauth);
        }
        public static GitLabClient Connect(string hostUrl, string username, string password, ApiVersion apiVersion)
        {
            var api = new Api(hostUrl, "");
            api._ApiVersion = apiVersion;
            string PrivateToken = null;

            if (apiVersion.UsesOauth())
            {
                //https://docs.gitlab.com/ee/api/oauth2.html#resource-owner-password-credentials
                var token    = api.Post().With(new oauth() { UserName =username, Password = password, GrantType = "password" }).To<token>(oauth.Url);
                PrivateToken = token.AccessToken;
            }
            else
            {
                var session = api.Post().To<Session>($"/session?{(apiVersion== ApiVersion.V3_1?"email":"login")}={HttpUtility.UrlEncode(username)}&password={HttpUtility.UrlEncode(password)}");
                PrivateToken = session.PrivateToken;
            }
            return Connect(hostUrl, PrivateToken, apiVersion);
        }
        
        public static GitLabClient Connect(string hostUrl, string apiToken,  ApiVersion apiVersion)
        {
            return new GitLabClient(hostUrl, apiToken, apiVersion);
        }
        public static GitLabClient Connect(string hostUrl, string apiToken) {
            return new GitLabClient(hostUrl, apiToken);
        }

        public IRepositoryClient GetRepository(int projectId) {
            return new RepositoryClient(api, projectId);
        }

        public IMergeRequestClient GetMergeRequest(int projectId) {
            return new MergeRequestClient(api, projectId);
        }
    }
}