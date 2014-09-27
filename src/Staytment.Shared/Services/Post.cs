using System.Text;
using Windows.Devices.Geolocation;

namespace Staytment.Shared.Services
{
    public class Post
    {
        // TODO: Implement
        public string Content { get; private set; }
        public string Username { get; private set; }
        public Geopoint Location { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0}: {1} ({2}, {3})", Username, Content, Location.Position.Latitude, Location.Position.Longitude);
            return sb.ToString();
        }
    }
}
