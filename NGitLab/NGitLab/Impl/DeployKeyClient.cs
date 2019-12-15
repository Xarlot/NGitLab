using System;
using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab.Impl {
    public class DeployKeyClient : IDeployKeyClient {
        const string DeployKeysUrl = "/deploy_keys";
        const string ProjectDeployKeysUrl = "/projects/{0}/deploy_keys";
        const string ProjectDeployKeyEnableUrl = "/projects/{0}/deploy_keys/{1}/enable";
        const string ProjectDeployKeyUpdateUrl = "/projects/{0}/deploy_keys/{1}";
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

        public DeployKey Update(int projectId, DeployKey key)
        {
            if(key == null)
            {
                throw new ArgumentException($"{nameof(key)} is required and cannot be null");
            }

            return api.Put().With(key).To<DeployKey>(string.Format(ProjectDeployKeyUpdateUrl, projectId, key.Id));
        }

        public void Delete(int projectId, int deployKeyId)
        {
            api.Delete().To<DeployKey>(string.Format(ProjectDeployKeyUpdateUrl, projectId, deployKeyId));
        }
    }
}