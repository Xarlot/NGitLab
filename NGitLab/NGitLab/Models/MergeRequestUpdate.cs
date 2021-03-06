﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NGitLab.Json;

namespace NGitLab.Models {
    [DataContract]
    public class MergeRequestUpdate {
        [DataMember(Name = "source_branch")]
        public string SourceBranch { get; set; }

        [DataMember(Name = "target_branch")]
        public string TargetBranch { get; set; }

        [DataMember(Name = "assignee_id")]
        public int? AssigneeId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description;

        [DataMember(Name = "labels")]
        public string Labels;
        
        [DataMember(Name = "state_event")]
        [JsonConverter(typeof(StringEnumConverter), true)]
        public MergeRequestUpdateState? NewState { get; set; }
    }

    // ReSharper disable InconsistentNaming
    public enum MergeRequestUpdateState {
        close,
        reopen,
        merge,
    }
}