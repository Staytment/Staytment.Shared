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
            // TODO: Specify return type
            using (var req = new ListPostsRequest(ApiKey))
                return await GetPostsInternal(req.GetResponse(position, maxDistance));
        }
        public async Task<PostCollection> GetPosts(Geopoint position, int maxDistance, int limit)
        {
            // TODO: Specify return type
            using (var req = new ListPostsRequest(ApiKey))
                return await GetPostsInternal(req.GetResponse(position, maxDistance, limit));
        }

        private async Task<PostCollection> GetPostsInternal(Task<ListPostsResponse> resultTask)
        {
            // TODO: Specify return type
            var res = await resultTask;
            // TODO: process response

            throw new NotImplementedException();
        }
    }
}
