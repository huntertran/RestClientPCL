namespace RestClientNetStandard.Model
{
    using System.Collections.Generic;
    using System.Net.Http;

    /// <summary>
    /// API segment interface. You can re-implement it if you like
    /// </summary>
    public interface IApiSegment
    {
        /// <summary>
        /// Name of the segment
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Method of the API
        /// </summary>
        HttpMethod Method { get; set; }

        /// <summary>
        /// The uri part that after the base part
        /// </summary>
        string UrlSegment { get; set; }

        /// <summary>
        /// List of the headers
        /// </summary>
        IDictionary<string, string> Headers { get; set; }

        /// <summary>
        /// List of the parameters
        /// </summary>
        IDictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// List of the url-encoded form contents
        /// </summary>
        IDictionary<string, string> FormUrlEncodedContents { get; set; }
    }
}
