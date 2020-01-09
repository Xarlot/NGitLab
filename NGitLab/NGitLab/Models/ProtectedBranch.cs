using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NGitLab.Models {
    [DataContract]
    public class ProtectedBranch
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "push_access_levels")]
        public IEnumerable<ProtectedBranchInfo> pushAcessLevel { get; set; }
        [DataMember(Name = "merge_access_levels")]
        public IEnumerable<ProtectedBranchInfo> mergeAcessLevel { get; set; }
    }
    
}