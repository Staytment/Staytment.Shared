using System.Device.Location;
using System.Diagnostics;
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
            Debug.Assert(_viewModel != null);
            _viewModel.Client = new StaytmentClient(ApiKey);
            Initialize();
        }

        private async void Initialize()
        {
            await _viewModel.Initialize();
            var template = (ControlTemplate)FindResource("CutomPushpinTemplate");
            foreach (var post in _viewModel.CurrentPosts)
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
