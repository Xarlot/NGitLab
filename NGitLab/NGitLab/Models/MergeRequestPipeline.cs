using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NGitLab.Json;
using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class MergeRequestPipeline
    {
        [DataMember(Name = "id")]
        public int id { get; set; }
        [DataMember(Name = "sha")]
        public string sha { get; set; }
        [DataMember(Name = "ref")]
        public string @ref { get; set; }
        [DataMember(Name = "status")]
        [JsonConverter(typeof(StringEnumConverter), true)]
        public MergeRequestPipelineStatus status { get; set; }
        [DataMember(Name = "web_url")]
        public string web_url { get; set; }
    }
}

