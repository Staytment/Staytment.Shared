using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Staytment.Shared.Services.Api
{
    public class ListPostsResponse : IApiResponse
    {
        [DataMember(Name = "type")]
        public GeoJsonObjectType Type { get; set; }
        [DataMember(Name = "features")]
        public List<Feature> Features { get; set; }
    }

    //[DataContract]
    //public class PostResponse
    //{
    //    [DataMember(Name = "type")]
    //    public GeoJsonObjectType Type { get; set; }
    //    [DataMember(Name = "geometry")]
    //    public Geometry Geometry { get; set; }
    //    [DataMember(Name = "properties")]
    //    public Properties Properties { get; set; }
    //    [DataMember(Name = "_id")]
    //    public string Id { get; set; }
    //}

    public enum GeoJsonObjectType
    {
        Feature,
        FeatureCollection
    }
    public enum GeometryType
    {
        Point,
        Line,
        Polygon
    }
}
