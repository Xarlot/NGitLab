using System;
using System.Runtime.Serialization;

namespace NGitLab.Models {
    [DataContract]
    public class IssueTimeTrack {

        [DataMember(Name = "human_time_estimate")]
        public string humanTimeEstimate { get; set; }

        [DataMember(Name = "human_total_time_spent")]
        public string humanTotalTimeSpent { get; set; }

        [DataMember(Name = "time_estimate")]
        public int timeEstimate { get; set; }

        [DataMember(Name = "total_time_spent")]
        public int TotalTimeSpent { get; set; }
        
    }
}