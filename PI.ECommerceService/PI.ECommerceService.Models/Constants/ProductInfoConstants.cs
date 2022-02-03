using System.Collections.Generic;

namespace PI.ECommerceService.Models.Constants
{
    /// <summary>
    /// All Product collection constants are declared here.
    /// </summary>
    public static class ProductInfoConstants
    {
        /// <summary>
        /// Id of the Product in collection.
        /// </summary>
        public const string Id = "_id";

        /// <summary>
        /// Price of the product in product collection.
        /// </summary>
        public const string Price = "pricing.price";

        /// <summary>
        /// Categories of the product in product collection.
        /// </summary>
        public const string Categories = "categories";

        /// <summary>
        /// Category.0 of the product in product collection.
        /// </summary>
        public const string Category0 = "category.0";

        /// <summary>
        /// Category.1 of the product in product collection.
        /// </summary>
        public const string Category1 = "category.1";

        /// <summary>
        /// Category.2 of the product in product collection.
        /// </summary>
        public const string Category2 = "category.2";

        /// <summary>
        /// Department of the product in product collection.
        /// </summary>
        public const string Department = "department";

        /// <summary>
        /// Item of the product in product collection.
        /// </summary>
        public const string Item = "item";

        /// <summary>
        /// Description of the product in product collection.
        /// </summary>
        public const string Description = "description";

        /// <summary>
        /// All attributes of the product in product collection.
        /// </summary>
        public static readonly Dictionary<string, string> Attributes = new Dictionary<string, string>()
        {
            { "size", "attributes.size" },
            { "material", "attributes.material" },
            { "ram", "attributes.ram" },
            { "diskSpace", "attributes.diskSpace" },
        };
    }
}
