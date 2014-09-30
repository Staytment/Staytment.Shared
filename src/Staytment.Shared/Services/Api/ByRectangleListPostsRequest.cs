using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Staytment.Shared.Net;

namespace Staytment.Shared.Services.Api
{
    public class ByRectangleListPostsRequest : ListPostsRequest
    {
        protected const string ApiUrl2 = ApiUrl + "/by-rectangle";

        public ByRectangleListPostsRequest()
            : base(null)
        { }

        public Task<ListPostsResponse> GetResponse(GeoRectangle rectangle, Geopoint point3)
        {
            return GetResponse(rectangle, DefaultLimit);
        }

        public Task<ListPostsResponse> GetResponse(GeoRectangle rectangle, int limit)
        {
            if (rectangle == null)
                throw new ArgumentNullException("rectangle");

            limit = Math.Min(MaxLimit, Math.Max(MinLimit, limit)); // Clamp limit to 1-25

            var data = new ByPointListRequestData(rectangle, limit);

            var requestUri = CreateUri(ApiUrl2, data);

            return GetAsync(requestUri);
        }


        private struct ByPointListRequestData : IQueryStringable
        {
            // This struct is only for serialization, so no getter/setter needed. May change later.
            // TODO: Also: Find solution for correct casing since JSON.NET ignores [DataMember(Name)] when serializing.
            internal double lat1;
            internal double long1;
            internal double lat2;
            internal double long2;
            internal double lat3;
            internal double long3;
            internal double lat4;
            internal double long4;
            internal int limit;

            public ByPointListRequestData(GeoRectangle rectangle, int limit)
            {
                Debug.Assert(limit >= 0);

                lat1 = rectangle.A.Position.Latitude;
                long1 = rectangle.A.Position.Longitude;
                lat2 = rectangle.B.Position.Latitude;
                long2 = rectangle.B.Position.Longitude;
                lat3 = rectangle.C.Position.Latitude;
                long3 = rectangle.C.Position.Longitude;
                lat4 = rectangle.D.Position.Latitude;
                long4 = rectangle.D.Position.Longitude;

                this.limit = limit;
            }

            // TODO: Automate the ToQueryString process usign reflection
            public QueryString ToQueryString()
            {
                var qs = new QueryString();
                qs["lat1"] = lat1.ToString("F", CultureInfo.InvariantCulture);
                qs["long1"] = long1.ToString("F", CultureInfo.InvariantCulture);
                qs["lat2"] = lat2.ToString("F", CultureInfo.InvariantCulture);
                qs["long2"] = long2.ToString("F", CultureInfo.InvariantCulture);
                qs["lat3"] = lat3.ToString("F", CultureInfo.InvariantCulture);
                qs["long3"] = long3.ToString("F", CultureInfo.InvariantCulture);
                qs["lat4"] = lat4.ToString("F", CultureInfo.InvariantCulture);
                qs["long4"] = long4.ToString("F", CultureInfo.InvariantCulture);
                qs["limit"] = limit.ToString();
                return qs;
            }
        }
    }
}
