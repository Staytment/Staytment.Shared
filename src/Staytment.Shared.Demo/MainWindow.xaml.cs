using System.Device.Location;
using System.Diagnostics;
using System.Windows;
using Windows.Devices.Geolocation;
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
            var nearbyPosts = await cl.GetPosts(new Geopoint(new GeoCoordinate()), 25000);

            _viewModel.CurrentPosts = nearbyPosts;

            foreach (var post in nearbyPosts)
            {
                Trace.WriteLine(post.Content);
            }
        }
    }
}
