using System;
using System.Diagnostics;
using System.Text;
using Windows.Devices.Geolocation;

namespace Staytment.Shared.Services
{
    public class Post
    {
        // TODO: Implement
        public string Content { get; private set; }
        public PostUser User { get; private set; }
        public Geopoint Location { get; private set; }

        public string Id { get; private set; }

        public Post(Api.Feature feature)
        {
            if (feature == null)
                throw new ArgumentNullException("feature");
            Id = feature.Id;
            Location = feature.Geometry.Point;
            Content = feature.Properties.Content;
            User = new PostUser(feature.Properties.User);

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0}: {1} ({2}, {3})", User, Content, Location.Position.Latitude, Location.Position.Longitude);
            return sb.ToString();
        }
    }

    public class PostUser
    {
        public string Name { get; private set; }
        public string Id { get; private set; }

        public PostUser(Api.User user)
        {
            Debug.Assert(user != null);
            Id = user.Id;
            Name = user.Name;
        }

        public override string ToString()
        {
            return string.Format("{0} (#{1})", Name, Id);
        }
    }
}
