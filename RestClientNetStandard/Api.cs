namespace RestClientNetStandard
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The main class that you will use to make request
    /// </summary>
    public class Api
    {
        /// <summary>
        /// Specify the scheme of request: Http or Https
        /// </summary>
        public UriScheme Scheme { get; set; } = UriScheme.Http;

        /// <summary>
        /// Base URL. For example: maps.googleapis.com
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Specify port if api have one
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Send the request, return string
        /// </summary>
        /// <param name="segment">UrlSegment = "/maps/api/geocode/json", Method = HttpMethod.Get</param>
        /// <param name="handler">null as default</param>
        /// <returns></returns>
        public async Task<string> SendTask(IApiSegment segment, HttpClientHandler handler = null)
        {
            HttpResponseMessage responseMessage = await GetResponseTask(segment, handler);

            if (responseMessage == null)
            {
                throw new Exception("Null response");
            }

            var result = await responseMessage.Content.ReadAsStringAsync();
            return result;
        }

        /// <summary>
        /// Send the request, return HttpResponseMessage
        /// </summary>
        /// <param name="segment">UrlSegment = "/maps/api/geocode/json", Method = HttpMethod.Get</param>
        /// <param name="handler">null as default</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetResponseTask(IApiSegment segment, HttpClientHandler handler = null)
        {
            if (handler == null)
            {
                handler = DefaultHandler();
            }

            Uri uri = BuildUri(segment);


            HttpClient httpClient = new HttpClient(handler);

            HttpRequestMessage requestMessage = new HttpRequestMessage(segment.Method, uri);

            if (segment.Headers.Any())
            {
                foreach (KeyValuePair<string, string> segmentHeader in segment.Headers)
                {
                    requestMessage.Headers.TryAddWithoutValidation(segmentHeader.Key, segmentHeader.Value);
                }
            }

            if (segment.FormUrlEncodedContents.Any())
            {
                requestMessage.Content = new FormUrlEncodedContent(segment.FormUrlEncodedContents);
            }

            if (!string.IsNullOrEmpty(segment.RequestBody))
            {
                requestMessage.Content = new StringContent(segment.RequestBody);
            }

            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            return responseMessage;
        }

        private Uri BuildUri(IApiSegment segment)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var parameter in segment.Parameters)
            {
                stringBuilder.Append(parameter.Key);
                stringBuilder.Append('=');
                stringBuilder.Append(parameter.Value);
                stringBuilder.Append('&');
            }
            UriBuilder uriBuilder = new UriBuilder
            {
                Scheme = Scheme.ToString(),
                Host = BaseUrl,
                Path = segment.UrlSegment,
                Query = stringBuilder.ToString().TrimEnd('&')
            };
            if (Port != 0)
            {
                uriBuilder.Port = Port;
            }

            return uriBuilder.Uri;
        }

        private HttpClientHandler DefaultHandler()
        {
            return new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip |
                                         DecompressionMethods.Deflate |
                                         DecompressionMethods.None,
                AllowAutoRedirect = true
            };
        }
    }
}
