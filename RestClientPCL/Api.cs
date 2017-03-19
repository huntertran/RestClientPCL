namespace RestClientPCL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Model;

    public class Api
    {
        public UriScheme Scheme { get; set; } = UriScheme.Http;

        public string BaseUrl { get; set; }

        public int Port { get; set; }

        public async Task<string> SendAsync(ApiSegment segment, HttpClientHandler handler = null)
        {
            HttpResponseMessage responseMessage = await GetResponseTask(segment, handler);

            if (responseMessage == null)
            {
                throw new Exception("Null response");
            }

            var result = await responseMessage.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<HttpResponseMessage> GetResponseTask(ApiSegment segment, HttpClientHandler handler = null)
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

            requestMessage.Content = new FormUrlEncodedContent(segment.Parameters);

            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            return responseMessage;
        }

        private Uri BuildUri(ApiSegment segment)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var parameter in segment.Parameters)
            {
                stringBuilder.Append(parameter.Key);
                stringBuilder.Append('=');
                stringBuilder.Append(parameter.Value);
            }
            UriBuilder uriBuilder = new UriBuilder(
                Scheme.ToString(), 
                BaseUrl, 
                Port, 
                segment.UrlSegment,
                stringBuilder.ToString());
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