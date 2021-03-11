using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NGitLab.Models {
    [DataContract]
    public class IssueCreate {
        [DataMember(Name = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
        
        [DataMember(Name = "due_date")]
        public DateTime? dueDate { get; set; }

        //Comma-separated list of label names
        [DataMember(Name = "labels")]
        public string[] Labels { get; set; }

        [DataMember(Name = "milestone_id")]
        public int milestoneId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "assignee_ids")]
        public int[] assigneeIds { get; set; }
    }
}