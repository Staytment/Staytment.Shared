using System.Runtime.Serialization;
using Windows.Devices.Geolocation;

#if PLATFORM_DESKTOP

using BasicGeoposition = System.Device.Location.GeoCoordinate;

#endif

namespace Staytment.Shared.Services.Api
{
    [DataContract]
    public class Geometry
    {
        [DataMember(Name = "type")]
        public GeometryType Type { get; set; }

        [DataMember(Name = "coordinates")]
        public double[] Coordinates { get; set; }

        public Geopoint Point
        {
            get { return new Geopoint(new BasicGeoposition() { Latitude = Coordinates[1], Longitude = Coordinates[0] }); }
        }
    }
}
