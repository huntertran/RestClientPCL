using System;
using System.Collections.Generic;

namespace RestClientPCL.Extension
{
    public static class UriBuilderExtension
    {
        /// <summary>
        /// Sets the specified query parameter key-value pair of the URI.
        /// If the key already exists, the value is overwritten.
        /// </summary>
        public static UriBuilder SetQueryParam(this UriBuilder uri, string key, string value)
        {
            //var collection = uri.ParseQuery();

            //// add (or replace existing) key-value pair
            //collection.Set(key, value);

            //string query = collection
            //    .AsKeyValuePairs()
            //    .ToConcatenatedString(pair =>
            //        pair.Key == null
            //            ? pair.Value
            //            : pair.Key + "=" + pair.Value, "&");

            //uri.Query = query;

            string[] queries = uri.Query.TrimStart('?').Split('&');
            

            return uri;
        }
    }
}