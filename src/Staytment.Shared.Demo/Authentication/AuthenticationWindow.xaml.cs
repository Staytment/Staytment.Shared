using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Staytment.Shared.Demo.ViewModels;
using Staytment.Shared.Services.Api;

namespace Staytment.Shared.Demo.Authentication
{
    /// <summary>Interaction logic for AuthenticationWindow.xaml</summary>
    public partial class AuthenticationWindow
    {
        private readonly Auth _authenticator;
        public AuthenticationWindow(Auth authenticator)
        {
            InitializeComponent();
            _authenticator = authenticator;
            var dc = (BrowserModel)DataContext;

//            dc.Url = _authenticator.AuthUrl;
            dc.Title = "Authentication using " + _authenticator.DisplayName;

            authBrowser.Navigated += authBrowser_Navigated;
            authBrowser.NavigationService.Navigate(new Uri(_authenticator.AuthUrl));
        }


        private TaskCompletionSource<UserAccess> _currentTcs;
        public Task<UserAccess> CreateAccessByUserAsync()
        {
            _currentTcs = new TaskCompletionSource<UserAccess>();
            var res = ShowDialog();
            if (res != true)
                return null;
            return _currentTcs.Task;
        }

        private async void authBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri == null)
                return;

            if (e.Uri.AbsolutePath.Equals(_authenticator.CallbackAbsolutePath, StringComparison.InvariantCultureIgnoreCase))
            {
                Debug.Assert(_currentTcs != null);
                Debug.Assert(e.WebResponse != null);
                var res = e.WebResponse.GetResponseStream();
                Debug.Assert(res != null);
                using (var sr = new StreamReader(res))
                {
                    var jsonString = await sr.ReadToEndAsync();
                    var access = UserAccess.FromString(jsonString);
                    _currentTcs.TrySetResult(access);
                    DialogResult = access != null && !string.IsNullOrWhiteSpace(access.ApiKey);
                }
                Close();
                Debugger.Break();
            }
        }
    }
}
