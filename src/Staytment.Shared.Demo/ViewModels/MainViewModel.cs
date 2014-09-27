using System.Windows.Input;
using Staytment.Shared.Demo.Commands;
using Staytment.Shared.Services;

namespace Staytment.Shared.Demo.ViewModels
{
    class MainViewModel : ViewModel
    {
        private PostCollection _currentPosts;

        public PostCollection CurrentPosts
        {
            get { return _currentPosts; }
            set
            {
                if (_currentPosts != value)
                {
                    _currentPosts = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CreatePost { get; private set; }


        public MainViewModel()
        {
            CreatePost = new CreatePostCommand();
        }
    }
}
