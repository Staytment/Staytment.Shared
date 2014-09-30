using System.Runtime.Serialization;

namespace Staytment.Shared.Services.Api
{
    public class Feature
    {
        [DataMember(Name = "type")]
        public GeoJsonObjectType Type { get; set; }
        [DataMember(Name = "geometry")]
        public Geometry Geometry { get; set; }
        [DataMember(Name = "properties")]
        public Properties Properties { get; set; }
        [DataMember(Name = "_id")]
        public string Id { get; set; }
    }
}
