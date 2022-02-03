using System.Collections.Generic;
using Newtonsoft.Json;

namespace PI.ECommerceService.Models.DTO.Product
{
    /// <summary>
    /// Rating Details of the product sent in api response.
    /// </summary>
    public class RatingDTO
    {
        /// <summary>
        /// Gets or sets AggregateRating of the product.
        /// </summary>
        [JsonProperty("aggregateRating")]
        public double AggregateRating { get; set; }

        /// <summary>
        /// Gets or sets TotalReviews of the product.
        /// </summary>
        [JsonProperty("totalReviews")]
        public int TotalReviews { get; set; }

        /// <summary>
        /// Gets or sets Stars of the product.
        /// </summary>
        [JsonProperty("stars")]
        public List<int> Stars { get; set; }
    }
}