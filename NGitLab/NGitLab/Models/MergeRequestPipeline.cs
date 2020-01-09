using System.Runtime.Serialization;

namespace NGitLab.Models
{
    public class MergeRequestPipeline
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sha { get; set; }
        [DataMember(Name = "ref")]
        public string Ref { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string web_url { get; set; }
    }
}