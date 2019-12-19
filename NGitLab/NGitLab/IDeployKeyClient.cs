using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab {
    public interface IDeployKeyClient {
        /// <summary>
        ///     Get a list of all deploy keys
        /// </summary>
        IEnumerable<DeployKey> Get();

        /// <summary>
        ///     Get a list of deploy keys for the specified project.
        /// </summary>
        IEnumerable<DeployKey> Get(int projectId);

        /// <summary>
        ///     Enables a deploy key on a project.  Returns the enabled deploy key on success.
        /// </summary>
        DeployKey Enable(int projectId, int deployKeyId);

        /// <summary>
        ///     Updates a deploy key on a project.  Returns the updated deploy key on success.
        /// </summary>
        DeployKey Update(int projectId, DeployKey key);

        /// <summary>
        ///     Deletes a deploy key from a project.
        /// </summary>
        void Delete(int projectId, int deployKeyId);
    }
}