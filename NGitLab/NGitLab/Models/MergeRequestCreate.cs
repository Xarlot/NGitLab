using System.Runtime.Serialization;

namespace NGitLab.Models {
    [DataContract]
    public class MergeRequestCreate {
        [DataMember(Name = "source_branch")]
        public string SourceBranch { get; set; }

        [DataMember(Name = "target_branch")]
        public string TargetBranch { get; set; }

        [DataMember(Name = "assignee_id")]
        public int? AssigneeId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
        
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "target_project_id")]
        public int? TargetProjectId { get; set; }
        [DataMember(Name = "labels")]
        public string[] Labels { get; set; }
        [DataMember(Name = "merge_when_pipeline_succeeds")]
        public bool? mergeWhenPipelineSucceeds { get; set; }
    }
}