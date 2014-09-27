using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Staytment.Shared.Net
{
    // Add to NTH?
    // TODO: Implement some dictionary interface and stuff
    public class QueryString : IQueryStringable
    {
        private readonly IDictionary<string, string> _parameters;

        public QueryString()
            : this(new Dictionary<string, string>())
        { }

        public QueryString(IDictionary<string, string> parameters)
        {
            _parameters = parameters ?? new Dictionary<string, string>();
        }

        public QueryString(Uri uri)
            : this(uri.ToString())
        { }

        public QueryString(string uri)
            : this()
        {
            Append(uri);
        }

        internal void Append(string uri)
        {
            var index = uri.IndexOf('?');
            var query = index > -1 ? uri.Substring(index + 1) : uri;

            var parts = query.Split('&');

            foreach (var part in parts.Select(p => p.Split('=')))
            {
                _parameters.Add(part[0], part.Length > 1 ? part[1] : null);
            }
        }

        public string this[string index]
        {
            get
            {
                string result;
                _parameters.TryGetValue(index, out result);
                return result;
            }
            set
            {
                _parameters[index] = value;
            }
        }

        public void Remove(string key)
        {
            _parameters.Remove(key);
        }

        public bool ContainsKey(string key)
        {
            return _parameters.ContainsKey(key);
        }

        public override string ToString()
        {
            // TODO: URLENCODE(!!)
            var sb = new StringBuilder();
            foreach (var parameter in _parameters)
            {
                sb.Append(parameter.Key);
                if (parameter.Value != null)
                {
                    sb.Append('=').Append(parameter.Value);
                }
            }
            return sb.ToString();
        }

        public QueryString ToQueryString()
        {
            return this;
        }
    }

    internal static class UriExtensions
    {
        public static Uri SetQuery(this Uri uri, QueryString query)
        {
            var ub = new UriBuilder(uri);
            ub.Query = query == null ? string.Empty : query.ToString();
            return ub.Uri;
        }
    }
}