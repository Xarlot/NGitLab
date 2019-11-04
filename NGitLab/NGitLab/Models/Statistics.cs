using System.Runtime.Serialization;

namespace NGitLab.Models {
    [DataContract]
    public class Statistics {
        [DataMember(Name = "commit_count")]
        public long CommitCount { get; set; }
        [DataMember(Name = "repository_size")]
        public long RepositorySize { get; set; }
        [DataMember(Name = "wiki_size")]
        public long WikiSize { get; set; }
        [DataMember(Name = "lfs_objects_size")]
        public long LfsObjectsSize { get; set; }
        [DataMember(Name = "job_artifacts_size")]
        public long JobsArtifactsSize { get; set; }
        [DataMember(Name = "packages_size")]
        public long PackageSize { get; set; }
    }
}