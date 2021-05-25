using System;
using System.Net.Http;
using System.Threading.Tasks;
using FerretlyClient;

namespace fetch_info
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Hydrate into an ApiClient instance
                var clientInfo = await new Client().GetApiClientInfo();

                Console.WriteLine($"Owner/Name: {clientInfo.Owner}");
                Console.WriteLine($"OrganizationId: {clientInfo.OrganizationId}");
                Console.WriteLine($"Callback URL: {clientInfo.StatusUpdateCallbackUrl}");
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"Exception: {exception.Message}");
            }
        }
    }
}
