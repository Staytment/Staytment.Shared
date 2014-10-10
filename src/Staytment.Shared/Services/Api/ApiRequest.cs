using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Staytment.Shared.Net;

namespace Staytment.Shared.Services.Api
{
    public abstract class ApiRequest<T> : IDisposable where T : class, IApiResponse
    {
        protected const string ApiBaseUrl = "http://api.staytment.com";
        private readonly HttpClient _client;
        private readonly string _apiKey;

        #region Ctor

        protected ApiRequest()
            : this(null)
        { }
        protected ApiRequest(string apiKey)
        {
            _client = new HttpClient();
            _apiKey = apiKey;
        }

        #endregion

        #region GetAsync

        [Obsolete]
        protected Task<T> GetAsync(string requestUri)
        {
            return GetAsync(CreateUri(requestUri));
        }
        protected async Task<T> GetAsync(Uri requestUri)
        {
            requestUri = CheckApiKey(requestUri);
            Debug.WriteLine("Get: " + requestUri);
            var response = await _client.GetAsync(requestUri);

            if (response.Content == null)
                return null;

            return await response.Content.ReadAsJsonObjectAsync<T>();
        }

        #endregion
        #region PostAsync

        [Obsolete]
        protected Task<T> PostAsync(string requestUri, HttpContent content)
        {
            return PostAsync(CreateUri(requestUri), content);
        }
        protected async Task<T> PostAsync(Uri requestUri, HttpContent content)
        {
            requestUri = CheckApiKey(requestUri);
            Debug.WriteLine("Post: " + requestUri);

            var response = await _client.PostAsync(requestUri, content);

            if (response.Content == null)
                return null;

            return await response.Content.ReadAsJsonObjectAsync<T>();
        }

        /// <remarks>content will be serialized as JSON</remarks>
        protected Task<T> PostAsync(Uri requestUri, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var str = new StringContent(json, Encoding.UTF8, "application/json");
            return PostAsync(requestUri, str);
        }

        #endregion

        private static Uri CreateUri(string uriString)
        {
            if (string.IsNullOrEmpty(uriString))
                return null;
            return new Uri(uriString, UriKind.RelativeOrAbsolute);
        }

        protected static Uri CreateUri(string uriString, IQueryStringable query)
        {
            var uri = CreateUri(uriString);
            if (query == null)
                return uri;
            return uri != null ? uri.SetQuery(query.ToQueryString()) : null;
        }

        /// <summary>Ensures that the request URI contains the API key if one is specified. If there isn't one specified, it removes the API key from the request URI.</summary>
        /// <param name="uri">The request URI</param>
        private Uri CheckApiKey(Uri uri)
        {
            if (uri == null)
                return null;
            const string apiKeyParam = "api_key";

            var query = new QueryString(uri);

            if (string.IsNullOrEmpty(_apiKey))
            {
                // Strip api key if class user put one into the url
                if (query.ContainsKey(apiKeyParam))
                    query.Remove(apiKeyParam);
            }
            else
            {
                query[apiKeyParam] = _apiKey;
            }

            return uri.SetQuery(query);
        }

        #region IDisposable

        public void Dispose()
        {
            ((IDisposable)_client).Dispose();
        }

        #endregion
    }
}
