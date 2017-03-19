namespace RestClientPCL.Test
{
    using Model;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ApiTest
    {
        [TestMethod]
        public async Task SendTaskTest()
        {
            //https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA
            Api api = new Api
            {
                BaseUrl = "maps.googleapis.com",
                Scheme = UriScheme.Https
            };

            ApiSegment apiSegment = new ApiSegment
            {
                UrlSegment = "/maps/api/geocode/json",
                Method = HttpMethod.Get
            };
            apiSegment.Parameters.Add("address", "1600 Amphitheatre Parkway, Mountain View, CA");

            var test = await api.SendTask(apiSegment);
            Assert.IsNotNull(test);
        }
    }
}
