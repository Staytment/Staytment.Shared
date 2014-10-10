using System.Device.Location;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Windows.Devices.Geolocation;
using Microsoft.Maps.MapControl.WPF;
using Staytment.Shared.Demo.ViewModels;
using Staytment.Shared.Services.Api;

namespace Staytment.Shared.Demo
{
    /// <summary>Interaction logic for MainWindow.xaml</summary>
    public partial class MainWindow : Window
    {
        private const string ApiKey = "<api-key>";
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = DataContext as MainViewModel;
            Init();
        }

        private async void Init()
        {
            var cl = new StaytmentClient(ApiKey);

            var rect = new GeoRectangle
            {
                TopLeft = new Geopoint(new GeoCoordinate(51.169872159530186, 9.408416748046875)),
                BottomRight = new Geopoint(new GeoCoordinate(51.169872159530186, 9.652862548828125))
            };

            var nearbyPosts = await cl.GetPosts(rect, 50, 50, 25);
            // cl.GetPosts(new Geopoint(new GeoCoordinate(51, 9.5)), 25000);

            _viewModel.CurrentPosts = nearbyPosts;
            var template = (ControlTemplate)this.FindResource("CutomPushpinTemplate");

            foreach (var post in nearbyPosts)
            {
                var p = new Pushpin
                {
                    Location = new Location(post.Location.Position.Latitude, post.Location.Position.Longitude),
                    Content = post.Content,
                    Template = template
                };
                lolMap.Children.Add(p);
            }
        }
    }
}
