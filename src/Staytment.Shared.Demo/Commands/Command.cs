using System;
using System.Windows.Input;

namespace Staytment.Shared.Demo.Commands
{
    internal abstract class Command : ICommand
    {
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);


        public event EventHandler CanExecuteChanged;

        protected void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, new EventArgs());
        }
    }
}
