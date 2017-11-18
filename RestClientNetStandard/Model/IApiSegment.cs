namespace RestClientNetStandard.Model
{
    using System.Collections.Generic;
    using System.Net.Http;

    public interface IApiSegment
    {
        string Name { get; set; }

        HttpMethod Method { get; set; }

        string UrlSegment { get; set; }

        IDictionary<string, string> Headers { get; set; }

        IDictionary<string, string> Parameters { get; set; }

        IDictionary<string, string> FormUrlEncodedContents { get; set; }
    }
}
