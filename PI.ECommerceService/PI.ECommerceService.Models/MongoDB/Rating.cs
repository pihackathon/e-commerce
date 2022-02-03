using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace PI.ECommerceService.Models.MongoDB
{
    /// <summary>
    /// Rating Details in MongoDB.
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Rating
    {
        /// <summary>
        /// Gets or sets AggregateRating of the product in Product collection.
        /// </summary>
        [BsonElement("aggregateRating")]
        public double AggregateRating { get; set; }

        /// <summary>
        /// Gets or sets TotalReviews of the product in Product collection.
        /// </summary>
        [BsonElement("totalReviews")]
        public int TotalReviews { get; set; }

        /// <summary>
        /// Gets or sets Stars of the product in Product collection.
        /// </summary>
        [BsonElement("stars")]
        public List<int> Stars { get; set; }
    }
}
