using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using PI.ECommerceService.Models.DTO.Product;

namespace PI.ECommerceService.Models.MongoDB
{
    /// <summary>
    /// Product Details in MongoDB.
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Products
    {
        /// <summary>
        /// Gets or sets Id of the product in Product collection.
        /// </summary>
        [BsonElement("ProductId")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Sku of the product in Product collection.
        /// </summary>
        [BsonElement("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets Item of the product in Product collection.
        /// </summary>
        [BsonElement("item")]
        public string Item { get; set; }

        /// <summary>
        /// Gets or sets Description of the product in Product collection.
        /// </summary>
        [BsonElement("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets ManufactureDetails of the product in Product collection.
        /// </summary>
        [BsonElement("manufactureDetails")]
        public ManufactureDetails ManufactureDetails { get; set; }

        /// <summary>
        /// Gets or sets Quantity of the product in Product collection.
        /// </summary>
        [BsonElement("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets Pricing of the product in Product collection.
        /// </summary>
        [BsonElement("pricing")]
        public Pricing Pricing { get; set; }

        /// <summary>
        /// Gets or sets Rating of the product in Product collection.
        /// </summary>
        [BsonElement("rating")]
        public Rating Rating { get; set; }

        /// <summary>
        /// Gets or sets Image of the product in Product collection.
        /// </summary>
        [BsonElement("image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets Attributes of the product in Product collection.
        /// </summary>
        [BsonElement("attributes")]
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        /// Gets or sets Category of the product in Product collection.
        /// </summary>
        [BsonElement("categories")]
        public List<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets Department of the product in Product collection.
        /// </summary>
        [BsonElement("department")]
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets created date of the product in Product collection.
        /// </summary>
        [BsonElement("insertedDate")]
        public DateTime InsertedDate { get; set; }

        /// <summary>
        /// Gets or sets last updated date of the product in Product collection.
        /// </summary>
        [BsonElement("updatedDate")]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets schema Version of the product in Product collection.
        /// </summary>
        [BsonElement("schemaVersion")]
        public int SchemaVersion { get; set; }
    }
}