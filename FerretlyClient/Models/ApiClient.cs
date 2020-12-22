using System;

namespace FerretlyClient.Models
{
    /// <summary>
    /// Information about the API client
    /// </summary>
    public class ApiClient
    {
        /// <summary>
        /// The id of the Ferretly user associated with the API client key
        /// </summary>
        public Guid SubscriberId { get; set; }

        /// <summary>
        /// The id of the Ferretly organization associated with the API client key
        /// </summary>
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Name of the API client key owner
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Comma-separated list of permissions associated with the API client
        /// </summary>
        public string Permissions { get; set; }

        /// <summary>
        /// Webhook URL
        /// </summary>
        public string StatusUpdateCallbackUrl { get; set; }

        /// <summary>
        /// A place to store additional, generic properties about the API Client
        /// </summary>
        /// <remarks>Typically an API client will use this to store configuration. Max length is 65536 (64K is all you need 8} )</remarks>
        public string ClientSpecificProperties { get; set; }
    }

}