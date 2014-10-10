using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Newtonsoft.Json;

namespace Staytment.Shared.Services.Api
{
    // TODO: May refactor to inherit from "PostRequest" to only have the constant in one class
    // TODO: May rename classes to have HTTP options as prefix. Eg. "PostPostsRequest", "GetPostsRequest"
    public class CreatePostRequest : ApiRequest<CreatePostResponse>
    {
        protected const string ApiUrl = ApiBaseUrl + "/posts/";

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
            if (string.IsNullOrEmpty(content)) // TODO: Content.IsValidContent?
                throw new ArgumentNullException("content");

            var data = new CreatePostRequestData(position, content);

            var requestUri = CreateUri(ApiUrl, null);

            // Documentation is wrong here, just dump the json into the request body
            /*
            var dataJson = data.ToJson();
            var cnt = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("post", dataJson)
            });
            */
            
            return PostAsync(requestUri, data);
        }

        private struct CreatePostRequestData
        {
            // This struct is only for serialization, so no getter/setter needed. May change later.
            // TODO: Also: Find solution for correct casing since JSON.NET ignores [DataMember(Name)] when serializing.
            [DataMember(Name = "message")]
            public string message;
            [DataMember(Name = "coordinates")]
            public double[] coordinates;

            public CreatePostRequestData(Geopoint position, string content)
            {
                Debug.Assert(position != null);
                Debug.Assert(!string.IsNullOrEmpty(content)); // TODO: Content.IsValidContent?

                message = content;
                coordinates = new[] { position.Position.Longitude, position.Position.Latitude };
            }

            public string ToJson()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }
}
