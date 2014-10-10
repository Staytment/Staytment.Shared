using System.Threading.Tasks;
using Staytment.Shared.Demo.ViewModels;

namespace Staytment.Shared.Demo
{
    internal static class PostCreator
    {
        public static async Task<PostDataModel> CreatePostByUserAsync()
        {
            var wnd = new CreatePostWindow();
            var res = await wnd.ShowDialogAsync();
            return res == true ? wnd.Data : null;
        }
    }
}
