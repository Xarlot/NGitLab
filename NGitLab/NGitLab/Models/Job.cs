using System;
using System.Runtime.Serialization;

namespace NGitLab.Models {

    [DataContract]
    public class Job {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "commit")]
        public Commit Commit { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [DataMember(Name = "started_at")]
        public DateTime? StartedAt { get; set; }
        
        [DataMember(Name = "finished_at")]
        public DateTime? FinishedAt { get; set; }
        
        [DataMember(Name = "duration")]
        public double? Duration { get; set; }
        
        [DataMember(Name = "artifacts_file")]
        public ArtifactsFile File { get; set; }
        
        [DataMember(Name = "artifacts_expire_at")]
        public DateTime? ArtifactsExpireAt { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "pipeline")]
        public PipelineData Pipeline { get; set; }
        
        [DataMember(Name = "ref")]
        public string Ref { get; set; }

        [DataMember(Name = "runner")]
        public RunnerData Runner { get; set; }
        
        [DataMember(Name = "stage")]
        public string Stage { get; set; }
        
        [DataMember(Name = "status")]
        public PipelineStatus Status { get; set; }
        
        [DataMember(Name = "tag")]
        public string Tag { get; set; }
        
        [DataMember(Name = "web_url")]
        public string WebUrl { get; set; }
        
        [DataMember(Name = "user")]
        public User User { get; set; }
    }
}
