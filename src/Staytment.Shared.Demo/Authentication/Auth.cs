using System;
using System.Threading.Tasks;

namespace Staytment.Shared.Demo.Authentication
{
    public abstract class Auth
    {
        public abstract string AuthUrl { get; }
        public abstract string DisplayName { get; }
        public abstract string CallbackAbsolutePath { get; }

        public async Task<string> RequestToken()
        {
            var wnd = new AuthenticationWindow(this);

            var access = await wnd.CreateAccessByUserAsync();
            if (access != null)
            {

                throw new NotImplementedException();
            }
            return null;
        }
    }
}
