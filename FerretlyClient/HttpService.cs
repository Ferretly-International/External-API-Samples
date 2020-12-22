using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FerretlyClient.Configuration;

namespace FerretlyClient
{
    public interface IHttpService
    {
        /// <summary>
        /// Use an HTTP POST request to send an object
        /// </summary>
        /// <param name="url">Relative to the <see cref="BaseUrl"/></param>
        /// <param name="body">Object to be included in the request body</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync(string url, object body);

        /// <summary>
        /// Perform an HTTP GET request
        /// </summary>
        /// <param name="url">Relative to the <see cref="BaseUrl"/></param>
        /// <param name="query">Query parameters (no leading ? necessary)</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetAsync(string url, string query = "");
        
        string BaseUrl { get; }
    }
    
    /// <summary>
    /// Basic HTTP service
    /// </summary>
    public class HttpService : IHttpService, IDisposable
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _baseUrl;
        
        public HttpService(FerretlyApi requestOptions)
        {
            foreach (var kvPair in requestOptions.Headers)
            {
                _httpClient.DefaultRequestHeaders.Add(kvPair.Key, kvPair.Value);
            }

            _baseUrl = requestOptions.BaseUrl.TrimEnd('/');
        }

        public string BaseUrl => _baseUrl;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostAsync(string url, object body)
        {
            return await _httpClient.PostAsync(GetFullUrl(url), 
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
        }

        private string GetFullUrl(string url)
        {
            return $"{_baseUrl}/{url.TrimStart('/')}";
        }

        public async Task<HttpResponseMessage> GetAsync(string url, string query = "")
        {
            var urlWithQuery = string.IsNullOrWhiteSpace(query)
                ? GetFullUrl(url)
                : $"{GetFullUrl(url)}?{query.TrimStart('?')}";
            return await _httpClient.GetAsync(urlWithQuery);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
