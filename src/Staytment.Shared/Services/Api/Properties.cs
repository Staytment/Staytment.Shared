using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Staytment.Shared.Services.Api
{
    [DataContract]
    public class Properties
    {
        [DataMember(Name = "message")]
        public string Content { get; set; }
        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }
        [DataMember(Name = "relevance")]
        public int Relevance { get; set; }
        [DataMember(Name = "user")]
        public User User { get; set; }
    }
}
