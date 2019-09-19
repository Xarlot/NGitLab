using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab.Impl {
    public class ProtectedBranchClient : IProtectedBranchClient {
        readonly Api api;
        readonly string protectedBranchesPath;

        public ProtectedBranchClient(Api api, string projectPath) {
            this.api = api;
            this.protectedBranchesPath = projectPath + "/protected_branches";
        }

        public IEnumerable<ProtectedBranch> All() {
            return api.Get().GetAll<ProtectedBranch>(protectedBranchesPath);
        }

        public ProtectedBranch Get(string name) {
            return api.Get().To<ProtectedBranch>(protectedBranchesPath + "/" + name);
        }
    }
}