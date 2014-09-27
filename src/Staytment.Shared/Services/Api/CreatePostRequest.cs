using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Staytment.Shared.Services.Api
{
    // TODO: May refactor to inherit from "PostRequest" to only have the constant in one class
    // TODO: May rename classes to have HTTP options as prefix. Eg. "PostPostsRequest", "GetPostsRequest"
    public class CreatePostRequest : ApiRequest<CreatePostResponse>
    {
        protected const string ApiUrl = ApiBaseUrl + "/posts";

        protected const int MinLimit = 1;
        protected const int MaxLimit = 25;
        protected const int DefaultLimit = MaxLimit;

        // API key is needed, so only provide a constructor that takes one.
        public CreatePostRequest(string apiKey)
            : base(apiKey)
        { }

        public Task<CreatePostResponse> GetResponse(Geopoint position, string content)
        {
            if (position == null)
                throw new ArgumentNullException("position");
            if (string.IsNullOrEmpty(content)) // TODO: Message.IsValidContent?
                throw new ArgumentNullException("content");

            var data = new CreatePostRequestData(position, content);

            var requestUri = CreateUri(ApiUrl, null);

            return PostAsync(requestUri, data);
        }

        private struct CreatePostRequestData // Not QueryStringable since it is JSON in the post body
        {
            // This struct is only for serialization, so no getter/setter needed. May change later.
            // TODO: Also: Find solution for correct casing since JSON.NET ignores [DataMember(Name)] when serializing.
            [DataMember(Name = "message")]
            internal string message;
            [DataMember(Name = "coordinates")]
            internal double[] coordinates;

            public CreatePostRequestData(Geopoint position, string content)
            {
                Debug.Assert(position != null);
                Debug.Assert(!string.IsNullOrEmpty(content)); // TODO: Message.IsValidContent?

                message = content;
                coordinates = new[] { position.Position.Longitude, position.Position.Latitude };
            }
        }
    }
}
