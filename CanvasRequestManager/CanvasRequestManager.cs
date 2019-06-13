using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CanvasRequestManager
{
    public class CanvasRequester
    {
        private static readonly HttpClient Client = Startup.HttpClient;
        private string HttpProtocol = "https://";
        private string HttpDomain = "instructure.com";
        private string HttpSubDomain = "byui";
        private int HttpDefaultPort = -1;
        
        public CanvasRequester()
        {
            HttpSubDomain = "byui";
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("CANVAS_API_TOKEN"));
        }

        public CanvasRequester(string subDomain)
        {
            HttpSubDomain = subDomain;
        }

        public async Task<JObject> GetAsync(string path)
        {
            var url = UrlBuilder(path);
            Console.WriteLine(url);
            var response = await Client.GetAsync(url);
            var result = response.Content.ReadAsStringAsync().Result;
            var obj = JObject.Parse(result);

            return obj;
        }

        private string UrlBuilder(string path)
        {
            string url = new UriBuilder(HttpProtocol, $"{HttpSubDomain}.{HttpDomain}", HttpDefaultPort, path).ToString();
            return url;
        }
    }
}
