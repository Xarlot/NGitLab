using System.Runtime.Serialization;

namespace NGitLab.Models {
    [DataContract]
    public class RunnerData {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        [DataMember(Name = "description")]
        public string Description { get; set; }
        
        [DataMember(Name = "ip_address")]
        public string Ip { get; set; }
        
        [DataMember(Name = "active")]
        public bool Active { get; set; }
        
        [DataMember(Name = "is_shared")]
        public bool Shared { get; set; }
        
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        [DataMember(Name = "online")]
        public bool Online { get; set; }
    }
}