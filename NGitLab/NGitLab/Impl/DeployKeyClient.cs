using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab.Impl {
    public class DeployKeyClient : IDeployKeyClient {
        const string DeployKeysUrl = "/deploy_keys";
        const string ProjectDeployKeysUrl = "/projects/{0}/deploy_keys";
        const string ProjectDeployKeyEnableUrl = "/projects/{0}/deploy_keys/{1}/enable";
        readonly Api api;

        public DeployKeyClient(Api api) {
            this.api = api;
        }

        public IEnumerable<DeployKey> Get() {
            return api.Get().GetAll<DeployKey>(DeployKeysUrl);
        }

        public IEnumerable<DeployKey> Get(int projectId) {
            return api.Get().GetAll<DeployKey>(string.Format(ProjectDeployKeysUrl, projectId));
        }

        public DeployKey Enable(int projectId, int deployKeyId)
        {
            return api.Post().To<DeployKey>(string.Format(ProjectDeployKeyEnableUrl, projectId, deployKeyId));
        }
    }
}