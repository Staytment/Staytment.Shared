using Windows.Devices.Geolocation;

namespace Staytment.Shared.Services.Api
{
    public class GeoRectangle
    {
        public Geopoint TopLeft { get; set; }
        public Geopoint BottomRight { get; set; }
    }
}
