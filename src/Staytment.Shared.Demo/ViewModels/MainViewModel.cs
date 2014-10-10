using System.Device.Location;
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
        }

        internal async Task Initialize()
        {
            CreatePost = new CreatePostCommand(this);

            if (Client == null)
                return;

            var cl = Client;
            var rect = new GeoRectangle
            {
                A = new Geopoint(new GeoCoordinate(51.169872159530186, 9.408416748046875)),
                B = new Geopoint(new GeoCoordinate(51.35120063065598, 9.408416748046875)),
                C = new Geopoint(new GeoCoordinate(51.35120063065598, 9.652862548828125)),
                D = new Geopoint(new GeoCoordinate(51.169872159530186, 9.652862548828125))
            };

            CurrentPosts = await cl.GetPosts(rect, 25);
        }
    }
}
