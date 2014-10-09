
namespace Staytment.Shared.Demo.Authentication
{
    public class GoogleAuth : Auth
    {
        public override string AuthUrl { get { return "http://api.staytment.com/auth/google"; } }
        public override string DisplayName { get { return "Google Account"; } }
        public override string CallbackAbsolutePath { get { return "/auth/google/callback"; } }
    }
}
