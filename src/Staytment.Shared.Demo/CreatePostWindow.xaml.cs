using System;
using System.Threading.Tasks;
using System.Windows;
using Staytment.Shared.Demo.ViewModels;

namespace Staytment.Shared.Demo
{
    /// <summary>Interaction logic for CreatePostWindow.xaml</summary>
    internal partial class CreatePostWindow
    {
        private readonly TaskCompletionSource<bool?> _tcs;
        public PostDataModel Data { get { return DataContext as PostDataModel; } }

        public CreatePostWindow()
        {
            InitializeComponent();
            _tcs = new TaskCompletionSource<bool?>();
        }

        public Task<bool?> ShowDialogAsync()
        {
            return _tcs.Task;
        }

        private bool _submitted;
        private void Submit()
        {
            _submitted = true;
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            _tcs.TrySetResult(_submitted);
            base.OnClosed(e);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Submit();
        }
    }
}
