using System.Text;

namespace RuneSharp.Utils
{
    internal class QueryStringBuilder
    {
        private IDictionary<string, string> _query;

        public QueryStringBuilder()
        {
            _query = new Dictionary<string, string>();
        }

        /// <summary>
        /// Add a parameter to the dictionary.
        /// </summary>
        /// <param name="key">Parameter name</param>
        /// <param name="val">Parameter value</param>
        /// <returns>QueryStringBuilder</returns>
        public QueryStringBuilder Add(string key, string val)
        {
            if (!_query.ContainsKey(key))
            {
                _query.Add(key, val);
            }

            return this;
        }

        /// <summary>
        /// Add a parameter to the dictionary.
        /// </summary>
        /// <param name="key">Parameter name</param>
        /// <param name="val">Parameter value</param>
        /// <returns>QueryStringBuilder</returns>
        public QueryStringBuilder Add(string key, int val)
        {
            return Add(key, val.ToString());
        }

        /// <summary>
        /// Remove a parameter from the dictionary.
        /// </summary>
        /// <param name="key">Parameter name</param>
        /// <returns>QueryStringBuilder</returns>
        public QueryStringBuilder Remove(string key)
        {
            if (_query.ContainsKey(key))
            {
                _query.Remove(key);
            }

            return this;
        }

        /// <summary>
        /// Format dictionary parameters as a query string.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("?");

            foreach (string key in _query.Keys)
            {
                sb.Append($"{key}={_query[key]}&");
            }

            sb.Length -= 1;

            return sb.ToString();
        }
    }
}
