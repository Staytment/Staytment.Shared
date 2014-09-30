using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Staytment.Shared.Services.Api
{
    public class StaytmentClient
    {
        public string ApiKey { get; set; }

        public StaytmentClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        public async Task<Post> CreatePost(Geopoint position, string content)
        {
            using (var req = new CreatePostRequest(ApiKey))
            {
                // TODO: Specify return type
                var res = await req.GetResponse(position, content);
                // TODO: process response

                throw new NotImplementedException();
            }
        }

        public async Task<PostCollection> GetPosts(Geopoint position, int maxDistance)
        {
            using (var req = new ByPointListPostsRequest())
                return await GetPostsInternal(req.GetResponse(position, maxDistance));
        }
        public async Task<PostCollection> GetPosts(Geopoint position, int maxDistance, int limit)
        {
            using (var req = new ByPointListPostsRequest())
                return await GetPostsInternal(req.GetResponse(position, maxDistance, limit));
        }

        private async Task<PostCollection> GetPostsInternal(Task<ListPostsResponse> resultTask)
        {
            var res = await resultTask;
            return new PostCollection(res);
        }

        public async Task<PostCollection> GetPosts(GeoRectangle rectangle, int limit)
        {
            using (var req = new ByRectangleListPostsRequest())
            {
                var res = await req.GetResponse(rectangle, limit);
                return new PostCollection(res);
            }
        }

    }
}
