using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab {
    public interface IProtectedBranchClient {
        IEnumerable<ProtectedBranch> All();
        ProtectedBranch Get(string name);
    }
}