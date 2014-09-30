using Windows.Devices.Geolocation;

namespace Staytment.Shared.Services.Api
{
    public class GeoRectangle
    {
        public Geopoint A { get; set; }
        public Geopoint B { get; set; }
        public Geopoint C { get; set; }
        public Geopoint D { get; set; }
    }
}
