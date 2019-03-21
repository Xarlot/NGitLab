using System.Collections.Generic;
using System.Runtime.Serialization;
using NGitLab.Impl;

namespace NGitLab.Models
{
    [DataContract]
    public class TreeOrBlob
    {
        [DataMember(Name = "id")]
        public Sha1 Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "type")]
        public ObjectType Type { get; set; }

        [DataMember(Name = "mode")]
        public string Mode { get; set; }
    }
}