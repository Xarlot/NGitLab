using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NGitLab.Models {
    [DataContract]
    public class MilestoneCreate
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "due_date")]
        public DateTime? dueDate { get; set; }

        [DataMember(Name = "start_date")]
        public DateTime? startDate { get; set; }
    }
}