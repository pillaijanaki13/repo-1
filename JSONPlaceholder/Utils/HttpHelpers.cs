using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TechTalk.SpecFlow;


namespace JSONPlaceholder
{
    class HttpHelpers
    {
        public static string baseUrl = "https://jsonplaceholder.typicode.com/";
        public static async Task<HttpResponseMessage> GetAsync(string uri)
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("URL:: " + uri);
            var response = await client.GetAsync(uri);
            return response;
        }
        public static async Task<string> PostJson<T>(T value, string url)
        {
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "*/*"),

            };
            Console.WriteLine("URL:: " + url);
            var response = await client.SendAsync(request);
            ScenarioContext.Current.Set(response);
            var contents = await response.Content.ReadAsStringAsync();
            return contents;
        }

        public static void PutJson<T>(T value, string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(url),
                Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json")
            };
            Console.WriteLine("URL:: " + url);
            ScenarioContext.Current.Set(client.SendAsync(request).Result);
        }
    }
}
