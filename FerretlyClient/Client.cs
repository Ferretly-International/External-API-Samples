using System.Net.Http;
using System.Threading.Tasks;
using FerretlyClient.Configuration;
using FerretlyClient.Models;
using Newtonsoft.Json;

namespace FerretlyClient
{
    /// <summary>
    /// An object which can be used to interface with the Ferretly External API
    /// </summary>
    public class Client
    {
        private readonly FerretlyApi _cfg;

        /// <summary>
        /// Create an instance, using an appSettings.json configuration section named FerretlyApi
        /// </summary>
        public Client()
        {
            _cfg = AppConfig.InitOptions<FerretlyApi>("FerretlyApi");
        }

        /// <summary>
        /// Create an instance using an appSettings.json configuration file with a section named by <paramref name="configSection"/>
        /// </summary>
        /// <param name="configSection"></param>
        public Client(string configSection)
        {
            _cfg = AppConfig.InitOptions<FerretlyApi>(configSection);
        }

        public Client(FerretlyApi config)
        {
            _cfg = config;
        }

        public async Task<ApiClient> GetApiClientInfo()
        {
            var result = await Get("ApiClient");
            return JsonConvert.DeserializeObject<ApiClient>(result);
        }

        private async Task<string> Get(string url)
        {
            using (var http = new HttpService(_cfg))
            {
                var response = await http.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }

                // get the result as a string
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}