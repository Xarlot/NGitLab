using System;
using System.Runtime.Serialization;

namespace NGitLab.Models {
    [DataContract]
    public class IssueUpdate {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "iid")]
        public int IssueId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        // Comma-separated label names for an issue
        [DataMember(Name = "labels")]
        public string[] Labels { get; set; }

        [DataMember(Name = "milestone_id", EmitDefaultValue = false)]
        public int milestoneId { get; set; }

        [DataMember(Name = "assignee_ids")]
        public int[] assigneeIds { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "confidential")]
        public bool confidential { get; set; }

        [DataMember(Name = "due_date")]
        public DateTime? dueDate { get; set; }
    }
}