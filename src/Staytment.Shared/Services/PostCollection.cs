using System.Collections.ObjectModel;
using Staytment.Shared.Services.Api;

namespace Staytment.Shared.Services
{
    public class PostCollection : ObservableCollection<Post>
    {
        public static PostCollection Empty { get { return new PostCollection(new ListPostsResponse()); } }

        public PostCollection(ListPostsResponse source)
        {
            if (source == null || source.Features == null || source.Features.Count == 0)
                return;
            foreach (var f in source.Features)
            {
                Add(new Post(f));
            }
        }
    }
}