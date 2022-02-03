using System;
using MongoDB.Bson.Serialization.Attributes;

namespace PI.ECommerceService.Models.MongoDB
{
    /// <summary>
    /// Pricing Details in MongoDB.
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Pricing
    {
        /// <summary>
        /// Gets or sets Price of the product in Product collection.
        /// </summary>
        [BsonElement("price")]
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets Currency of the product in Product collection.
        /// </summary>
        [BsonElement("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets Discount of the product in Product collection.
        /// </summary>
        [BsonElement("discount")]
        public int? Discount { get; set; }

        /// <summary>
        /// Gets or sets DiscountExpireAt of the product in Product collection.
        /// </summary>
        [BsonElement("discountExpireAt")]
        public DateTime? DiscountExpireAt { get; set; }
    }
}
