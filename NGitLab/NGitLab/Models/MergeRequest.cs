﻿using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NGitLab.Json;

namespace NGitLab.Models {
    [DataContract]
    public class MergeRequest {
        public const string Url = "/merge_requests";

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "iid")]
        public int Iid { get; set; }

        [DataMember(Name = "state")]
        [JsonConverter(typeof(StringEnumConverter), true)]
        public MergeRequestState? State { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "assignee")]
        public User Assignee { get; set; }

        [DataMember(Name = "author")]
        public User Author { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "downvotes")]
        public int Downvotes { get; set; }

        [DataMember(Name = "upvotes")]
        public int Upvotes { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "target_branch")]
        public string TargetBranch { get; set; }

        [DataMember(Name = "source_branch")]
        public string SourceBranch { get; set; }

        [DataMember(Name = "project_id")]
        public int ProjectId { get; set; }

        [DataMember(Name = "source_project_id")]
        public int? SourceProjectId { get; set; }

        [DataMember(Name = "target_project_id")]
        public int? TargetProjectId { get; set; }

        [DataMember(Name = "work_in_progress")]
        public bool? WorkInProgress { get; set; }

        [DataMember(Name = "labels")]
        public string[] Labels { get; set; }

        [DataMember(Name = "merge_when_pipeline_succeeds")]
        public bool? MergeWhenPipelineSucceeds { get; set; }

        [DataMember(Name = "has_conflicts")]
        public bool? HasConflicts { get; set; }

        [DataMember(Name = "merge_status")]
        [JsonConverter(typeof(StringEnumConverter), true)]
        public MergeRequestStatus? MergeStatus { get; set; }

        // Only filled by the "Get" method, not filled when using "All" or other methods (this is a API GitLab Rule)
        [DataMember(Name = "pipeline")]
        public MergeRequestPipeline Pipeline { get; set; }
    }
}
