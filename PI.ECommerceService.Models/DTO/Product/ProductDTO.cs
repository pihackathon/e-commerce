using System.Collections.Generic;
using Newtonsoft.Json;

namespace PI.ECommerceService.Models.DTO.Product
{
    /// <summary>
    /// product Details sent in api response.
    /// </summary>
    public class ProductDTO
    {
        /// <summary>
        /// Gets or sets Id of the product.
        /// </summary>
        [JsonProperty("ProductId")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Sku of the product.
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets Item of the product.
        /// </summary>
        [JsonProperty("item")]
        public string Item { get; set; }

        /// <summary>
        /// Gets or sets Description of the product.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets ManufactureDetails of the product.
        /// </summary>
        [JsonProperty("manufactureDetails")]
        public ManufactureDetailsDTO ManufactureDetails { get; set; }

        /// <summary>
        /// Gets or sets Quantity of the product.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets Pricing of the product.
        /// </summary>
        [JsonProperty("pricing")]
        public PricingDTO Pricing { get; set; }

        /// <summary>
        /// Gets or sets Rating of the product.
        /// </summary>
        [JsonProperty("rating")]
        public RatingDTO Rating { get; set; }

        /// <summary>
        /// Gets or sets Image of the product.
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets Attributes of the product.
        /// </summary>
        [JsonProperty("attributes")]
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        /// Gets or sets Category of the product.
        /// </summary>
        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets Department of the product.
        /// </summary>
        [JsonProperty("department")]
        public string Department { get; set; }
    }
}