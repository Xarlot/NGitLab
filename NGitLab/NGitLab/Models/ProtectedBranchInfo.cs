using System;
using System.Runtime.Serialization;

namespace NGitLab.Models {
    [DataContract]
    public class ProtectedBranchInfo {
        [DataMember(Name = "access_level")]
        public string accessLevel { get; set; }
        [DataMember(Name = "access_level_description")]
        public string accessLevelDescription { get; set; }

    }
}