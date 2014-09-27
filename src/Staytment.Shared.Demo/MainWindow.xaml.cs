using System.Device.Location;
using System.Diagnostics;
using System.Windows;
using Windows.Devices.Geolocation;
using Staytment.Shared.Api;

namespace Staytment.Shared.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string apiKey = "<api-key>";

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private async void Init()
        {
            var cl = new StaytmentClient(apiKey);
            var nearbyPosts = await cl.GetPosts(new Geopoint(new GeoCoordinate()), 25000);

            foreach (var post in nearbyPosts)
            {
                Trace.WriteLine(post.Content);
            }
        }
    }
}
