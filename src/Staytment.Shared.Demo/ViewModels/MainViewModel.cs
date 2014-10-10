using System.Device.Location;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Geolocation;
using Staytment.Shared.Demo.Commands;
using Staytment.Shared.Services;
using Staytment.Shared.Services.Api;

namespace Staytment.Shared.Demo.ViewModels
{
    class MainViewModel : ViewModel
    {
        public StaytmentClient Client { get; set; }

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
            Client = new StaytmentClient();
            CreatePost = new CreatePostCommand(this);
        }

        internal void Initialize()
        {

            Debug.Assert(Client != null);
#if FALSE
            var cl = Client;
            var rect = new GeoRectangle
            {
                TopLeft = new Geopoint(new GeoCoordinate(51.169872159530186, 9.408416748046875)),
                BottomRight = new Geopoint(new GeoCoordinate(51.169872159530186, 9.652862548828125))
            };
#endif

            // by-rectangle currently doesn't work, so skip this
            // CurrentPosts = await cl.GetPosts(rect, 3, 4, 25);
            CurrentPosts = PostCollection.Empty;
        }
    }
}
