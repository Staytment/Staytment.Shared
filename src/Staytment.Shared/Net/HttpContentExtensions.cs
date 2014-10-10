using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Staytment.Shared.Net
{
    internal static class HttpContentExtensions
    {
        // Maybe add to NTH-Library (but needs JSON.NET dependency)
        public static async Task<T> ReadAsJsonObjectAsync<T>(this HttpContent content)
        {
            var jsonObjectString = await content.ReadAsStringAsync();
            Debug.WriteLine(jsonObjectString);
            return JsonConvert.DeserializeObject<T>(jsonObjectString);
        }
    }
}
