using System.Collections.Generic;

namespace Staytment.Shared.Services.Api
{
    public abstract class ListPostsRequest : ApiRequest<ListPostsResponse>
    {
        protected const string ApiUrl = ApiBaseUrl + "/posts";

        protected const int MinLimit = 1;
        protected const int MaxLimit = 25;
        protected const int DefaultLimit = MaxLimit;

        // API key is needed, so only provide a constructor that takes one.
        protected ListPostsRequest(string apiKey)
            : base(apiKey)
        { }
    }
}
