using System;
using Newtonsoft.Json;

namespace PI.ECommerceService.Models.DTO.Product
{
    /// <summary>
    /// Pricing Details sent in api response.
    /// </summary>
    public class PricingDTO
    {
        /// <summary>
        /// Gets or sets Price of the product.
        /// </summary>
        [JsonProperty("price")]
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets Currency of the product.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets Discount of the product.
        /// </summary>
        [JsonProperty("discount")]
        public int? Discount { get; set; }

        /// <summary>
        /// Gets or sets DiscountExpireAt of the product.
        /// </summary>
        [JsonProperty("discountExpireAt")]
        public DateTime? DiscountExpireAt { get; set; }
    }
}
