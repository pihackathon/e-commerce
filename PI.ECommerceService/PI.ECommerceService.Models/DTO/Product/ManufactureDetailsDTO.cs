using Newtonsoft.Json;

namespace PI.ECommerceService.Models.DTO.Product
{
    /// <summary>
    /// Manufacture Details sent in api response.
    /// </summary>
    public class ManufactureDetailsDTO
    {
        /// <summary>
        /// Gets or sets Brand of the product.
        /// </summary>
        [JsonProperty("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets Model of the product.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }
    }
}
