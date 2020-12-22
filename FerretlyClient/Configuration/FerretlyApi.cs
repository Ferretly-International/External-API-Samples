using System.Collections.Generic;

namespace FerretlyClient.Configuration
{
    /// <summary>
    /// Configuration settings for API communication
    /// </summary>
    public class FerretlyApi
    {
        /// <summary>
        /// The URL of the API service
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Headers to be attached to each request message
        /// </summary>
        public Dictionary<string,string> Headers { get; set; }
    }
}