namespace RestClientNetStandard.Model
{
    using System.Collections.Generic;
    using System.Net.Http;

    /// <summary>
    /// Implementation of the API segment interface
    /// </summary>
    public class ApiSegment : IApiSegment
    {
        /// <summary>
        /// Name of the segment
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Method of the API
        /// </summary>
        public HttpMethod Method { get; set; } = HttpMethod.Get;

        /// <summary>
        /// The uri part that after the base part
        /// </summary>
        public string UrlSegment { get; set; }

        /// <summary>
        /// List of the headers
        /// </summary>
        public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// List of the parameters
        /// </summary>
        public IDictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// List of the url-encoded form contents
        /// </summary>
        public IDictionary<string, string> FormUrlEncodedContents { get; set; } = new Dictionary<string, string>();
    }
}
