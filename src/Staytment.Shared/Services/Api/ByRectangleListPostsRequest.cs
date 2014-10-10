using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Staytment.Shared.Net;

namespace Staytment.Shared.Services.Api
{
    public class ByRectangleListPostsRequest : ListPostsRequest
    {
        protected const string ApiUrl2 = ApiUrl + "/by-rectangle";

        public ByRectangleListPostsRequest()
            : base(null)
        { }

        public Task<ListPostsResponse> GetResponse(GeoRectangle rectangle, int horizontalResolution, int verticalResolution)
        {
            return GetResponse(rectangle, horizontalResolution, verticalResolution, DefaultLimit);
        }

        public Task<ListPostsResponse> GetResponse(GeoRectangle rectangle, int horizontalResolution, int verticalResolution, int limit)
        {
            if (rectangle == null)
                throw new ArgumentNullException("rectangle");

            limit = Math.Min(MaxLimit, Math.Max(MinLimit, limit)); // Clamp limit to 1-25

            var data = new ByPointListRequestData(rectangle, horizontalResolution, verticalResolution, limit);

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
            internal int vertical_resolution;
            internal int horizontal_resolution;
            internal int limit;

            public ByPointListRequestData(GeoRectangle rectangle, int horizontalResolution, int verticalResolution, int limit)
            {
                Debug.Assert(limit >= 0);

                lat1 = rectangle.TopLeft.Position.Latitude;
                long1 = rectangle.TopLeft.Position.Longitude;
                lat2 = rectangle.BottomRight.Position.Latitude;
                long2 = rectangle.BottomRight.Position.Longitude;
                vertical_resolution = verticalResolution;
                horizontal_resolution = horizontalResolution;
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
                qs["vertical_resolution"] = vertical_resolution.ToString(CultureInfo.InvariantCulture);
                qs["horizontal_resolution"] = horizontal_resolution.ToString(CultureInfo.InvariantCulture);
                qs["limit"] = limit.ToString(CultureInfo.InvariantCulture);
                return qs;
            }
        }
    }
}
