using System;
using System.Threading.Tasks;

namespace Staytment.Shared.Demo.Authentication
{
    abstract class Auth
    {
        protected abstract string AuthUrl { get; }

        public Task<string> RequestToken()
        {
            var url = AuthUrl;

            var wnd = new BrowserWindow("Staytment Authentication", url);

            var success = wnd.ShowDialog();
            if (success == true)
            {

                throw new NotImplementedException();
            }
            else
            {
                return Task.FromResult<string>(null);
            }
        }
    }
}
