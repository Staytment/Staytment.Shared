using Staytment.Shared.Api;

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
    }
}
