using System.Device.Location;
using System.Windows;
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
                A = new Geopoint(new GeoCoordinate(51.169872159530186, 9.408416748046875)),
                B = new Geopoint(new GeoCoordinate(51.35120063065598, 9.408416748046875)),
                C = new Geopoint(new GeoCoordinate(51.35120063065598, 9.652862548828125)),
                D = new Geopoint(new GeoCoordinate(51.169872159530186, 9.652862548828125))
            };

            var nearbyPosts = await cl.GetPosts(rect, 25);
            // cl.GetPosts(new Geopoint(new GeoCoordinate(51, 9.5)), 25000);

            _viewModel.CurrentPosts = nearbyPosts;

            foreach (var post in nearbyPosts)
            {
                var p = new Pushpin
                {
                    Location = new Location(post.Location.Position.Latitude, post.Location.Position.Longitude),
                    Content = post.Content
                };
                lolMap.Children.Add(p);
            }

            var l = new LocationCollection
            {
                new Location(rect.A.Position.Latitude, rect.A.Position.Longitude),
                new Location(rect.B.Position.Latitude, rect.B.Position.Longitude),
                new Location(rect.C.Position.Latitude, rect.C.Position.Longitude),
                new Location(rect.D.Position.Latitude, rect.D.Position.Longitude),
                new Location(rect.A.Position.Latitude, rect.A.Position.Longitude)
            };

            lolMap.Children.Add(new MapPolyline
            {
                Locations = l,
                Stroke = Brushes.Red,
                StrokeThickness = 2.0
            });
        }
    }
}
