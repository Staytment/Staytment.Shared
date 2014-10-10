using System;
using System.Device.Location;
using System.Diagnostics;
using Windows.Devices.Geolocation;
using Staytment.Shared.Demo.ViewModels;

namespace Staytment.Shared.Demo.Commands
{
    internal class CreatePostCommand : Command
    {
        private readonly MainViewModel _model;
        public CreatePostCommand(MainViewModel model)
        {
            Debug.Assert(model != null);
            Debug.Assert(model.Client != null);
            _model = model;
        }
        public override bool CanExecute(object parameter)
        {
            return _model.Client != null && !string.IsNullOrWhiteSpace(_model.Client.ApiKey); // TODO: Implement?
        }

        public async override void Execute(object parameter)
        {
            var postData = await PostCreator.CreatePostByUserAsync();
            if (postData != null)
            {
#if DEBUG
                if (postData.Location == null)
                {
                    // Debug coords, because there is curently no GPS service implemented
                    postData.Location = new Geopoint(new GeoCoordinate(51.31924083521146, 9.562568664550781));
                }
#endif
                await _model.Client.CreatePost(postData.Location, postData.Content);
            }
        }
    }
}
