using System;
using System.Diagnostics;
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
                await _model.Client.CreatePost(postData.Location, postData.Content);
            }
        }
    }
}
