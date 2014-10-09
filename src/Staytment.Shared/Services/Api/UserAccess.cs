using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Staytment.Shared.Services.Api
{
    // [Serializable]
    [DataContract]
    public class UserAccess
    {
        [DataMember(Name = "provider")]
        public string Provider { get; set; }

        [DataMember(Name = "identifier")]
        public string Identifier { get; set; }

        [DataMember(Name = "email")]
        public string EMail { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "picture")]
        public string PictureUrl { get; set; }

        [DataMember(Name = "apiKey")]
        public string ApiKey { get; set; }

        [DataMember(Name = "_id")]
        public string Id { get; set; }

        public static UserAccess FromString(string authResponse)
        {
            return JsonConvert.DeserializeObject<UserAccess>(authResponse);
        }
    }
}
