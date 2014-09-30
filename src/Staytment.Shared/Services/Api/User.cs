using System.Runtime.Serialization;

namespace Staytment.Shared.Services.Api
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "_id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
