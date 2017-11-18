namespace RestClientPCL.Model
{
    using System.Collections.Generic;
    using System.Net.Http;

    public class ApiSegment : IApiSegment
    {
        public string Name { get; set; }

        public HttpMethod Method { get; set; } = HttpMethod.Get;

        public string UrlSegment { get; set; }

        public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        public IDictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

        public IDictionary<string, string> FormUrlEncodedContents { get; set; } = new Dictionary<string, string>();
    }
}
