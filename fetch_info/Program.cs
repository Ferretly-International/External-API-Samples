using System;
using System.Threading.Tasks;
using FerretlyClient;
using FerretlyClient.Configuration;
using FerretlyClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace fetch_info
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cfg = AppConfig.InitOptions<FerretlyApi>("FerretlyApi");

            using var http = new HttpService(cfg);
            var response = await http.GetAsync("ApiClient");
            
            // get the result as a string
            var result = await response.Content.ReadAsStringAsync();
            
            // pretty-print to console
            Console.WriteLine(JToken.Parse(result).ToString(Formatting.Indented));

            // Hydrate into an ApiClient instance
            var clientInfo = JsonConvert.DeserializeObject<ApiClient>(result);
            
            Console.WriteLine($"Owner/Name: {clientInfo.Owner}");
            Console.WriteLine($"OrganizationId: {clientInfo.OrganizationId}");
            Console.WriteLine($"Callback URL: {clientInfo.StatusUpdateCallbackUrl}");
        }
    }
}
