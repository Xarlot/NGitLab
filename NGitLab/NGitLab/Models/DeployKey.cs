using System;
using System.Runtime.Serialization;

namespace NGitLab.Models {
    [DataContract]
    public class DeployKey {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "can_push")]
        public bool CanPush { get; set; }
    }
}