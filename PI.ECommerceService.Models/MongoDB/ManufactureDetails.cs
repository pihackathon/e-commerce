using MongoDB.Bson.Serialization.Attributes;

namespace PI.ECommerceService.Models.MongoDB
{
    /// <summary>
    /// Manufacture Details in MongoDB.
    /// </summary>
    [BsonIgnoreExtraElements]
    public class ManufactureDetails
    {
        /// <summary>
        /// Gets or sets Brand of the product in Product collection.
        /// </summary>
        [BsonElement("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets Model of the product in Product collection.
        /// </summary>
        [BsonElement("model")]
        public string Model { get; set; }
    }
}
