using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Staytment.Shared.Net;

namespace Staytment.Shared.Services.Api
{
    public class ByPointListPostsRequest : ListPostsRequest
    {
        protected const string ApiUrl2 = ApiUrl + "/by-point";

        public ByPointListPostsRequest()
            : base(null)
        { }

        public Task<ListPostsResponse> GetResponse(Geopoint point, int maxDistance)
        {
            return GetResponse(point, maxDistance, DefaultLimit);
        }

        public Task<ListPostsResponse> GetResponse(Geopoint point, int maxDistance, int limit)
        {
            if (point == null)
                throw new ArgumentNullException("point");
            if (maxDistance < 0)
                throw new ArgumentException("maxDistance must be greater as or equal to 0");

            limit = Math.Min(MaxLimit, Math.Max(MinLimit, limit)); // Clamp limit to 1-25

            var data = new ByPointListRequestData(point, maxDistance, limit);

            var requestUri = CreateUri(ApiUrl2, data);

            return GetAsync(requestUri);
        }


        private struct ByPointListRequestData : IQueryStringable
        {
            // This struct is only for serialization, so no getter/setter needed. May change later.
            // TODO: Also: Find solution for correct casing since JSON.NET ignores [DataMember(Name)] when serializing.
            internal int limit;
            internal int distance;
            internal double lat;
            internal double @long;

            public ByPointListRequestData(Geopoint point, int maxDistance, int limit)
            {
                Debug.Assert(maxDistance >= 0);

                this.limit = limit;
                this.distance = maxDistance;
                this.lat = point.Position.Latitude;
                this.@long = point.Position.Longitude;
            }

            // TODO: Automate the ToQueryString process usign reflection
            public QueryString ToQueryString()
            {
                var qs = new QueryString();
                qs["limit"] = limit.ToString();
                qs["distance"] = distance.ToString();
                qs["lat"] = lat.ToString();
                qs["long"] = @long.ToString();
                return qs;
            }
        }
    }
}
