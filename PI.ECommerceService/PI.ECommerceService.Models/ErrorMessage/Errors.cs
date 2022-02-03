using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PI.ECommerceService.Models.ErrorMessage
{
    /// <summary>
    /// Error response.
    /// </summary>
    public class Errors
    {
        /// <summary>
        /// Gets or sets Error code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets Error message.
        /// </summary>
        public string Message { get; set; }
    }
}
