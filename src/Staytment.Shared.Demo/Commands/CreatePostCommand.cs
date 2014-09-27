using System;

namespace Staytment.Shared.Demo.Commands
{
    internal class CreatePostCommand : Command
    {
        public override bool CanExecute(object parameter)
        {
            return false; // TODO: Implement
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
