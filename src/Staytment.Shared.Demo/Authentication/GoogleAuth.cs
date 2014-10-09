using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography;
using AsyncOAuth;

namespace Staytment.Shared.Demo.Authentication
{
    //    abstract class OAuth
    //    {
    //        protected readonly HttpClient Client;

    //        protected OAuth(string consumerKey, string consumerSecret)
    //        {
    //            Debug.Assert(!string.IsNullOrEmpty(consumerKey));
    //            Debug.Assert(!string.IsNullOrEmpty(consumerSecret));
    //            Client = OAuthUtility.CreateOAuthClient(consumerKey, consumerSecret, new AccessToken("accessToken", "accessTokenSecret"));
    //        }

    //        static OAuth()
    //        {
    //#if PLATFORM_WINDOWS_STORE
    //            // Windows Store Apps
    //            AsyncOAuth.OAuthUtility.ComputeHash = (key, buffer) =>
    //            {
    //                var crypt = Windows.Security.Cryptography.Core.MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");
    //                var keyBuffer = Windows.Security.Cryptography.CryptographicBuffer.CreateFromByteArray(key);
    //                var cryptKey = crypt.CreateKey(keyBuffer);

    //                var dataBuffer = Windows.Security.Cryptography.CryptographicBuffer.CreateFromByteArray(buffer);
    //                var signBuffer = Windows.Security.Cryptography.Core.CryptographicEngine.Sign(cryptKey, dataBuffer);

    //                byte[] value;
    //                Windows.Security.Cryptography.CryptographicBuffer.CopyToByteArray(signBuffer, out value);
    //                return value;
    //            };
    //#else
    //            // Silverlight, Windows Phone, Console, Web, etc...
    //            OAuthUtility.ComputeHash = (key, buffer) => { using (var hmac = new HMACSHA1(key)) { return hmac.ComputeHash(buffer); } };
    //#endif
    //        }

    //        public abstract Task<AccessToken> Authorize();
    //    }

    //    class GoogleOAuth : OAuth
    //    {
    //        private const string ConsumerSecret = "";
    //        private const string ConsumerKey = "";

    //        public GoogleOAuth()
    //            : base(ConsumerKey, ConsumerSecret)
    //        { }


    //        public async Task<AccessToken> Authorize()
    //        {
    //            var authorizer = new OAuthAuthorizer(ConsumerKey, ConsumerSecret);

    //            // get request token
    //            var tokenResponse = await authorizer.GetRequestToken("http://api.staytment.com/auth/google");
    //            var requestToken = tokenResponse.Token;

    //            var pinRequestUrl = authorizer.BuildAuthorizeUrl("https://api.twitter.com/oauth/authorize", requestToken);

    //        }
    //}

    class GoogleAuth : Auth
    {
        protected override string AuthUrl { get { return "http://api.staytment.com/auth/google"; } }
    }
}
