using System;

namespace Staytment.Shared.Demo.Commands
{
    internal class CreatePostCommand : Command
    {
        public override bool CanExecute(object parameter)
        {
            return true; // TODO: Implement
        }

        public async override void Execute(object parameter)
        {
            var postData = await PostCreator.CreatePostByUserAsync();
            if (postData != null)
            {
                
            }
        }
    }
}
