namespace PI.ECommerceService.Models.Constants
{
    /// <summary>
    /// All MongoDB constants are declared here.
    /// </summary>
    public static class MongoDBConstants
    {
        /// <summary>
        /// Product collection name.
        /// </summary>
        public const string ProductCollectionName = "product";

        /// <summary>
        /// search operator of mongodb query.
        /// </summary>
        public const string SearchOperator = "$search";

        /// <summary>
        /// phrase operator of mongodb query.
        /// </summary>
        public const string PhraseOperator = "phrase";

        /// <summary>
        /// Auto complete operator of mongodb query.
        /// </summary>
        public const string AutoCompleteOperator = "autocomplete";

        /// <summary>
        /// compound operator of mongodb query.
        /// </summary>
        public const string CompoundOperator = "compound";

        /// <summary>
        /// must operator of mongodb query.
        /// </summary>
        public const string MustOperator = "must";

        /// <summary>
        /// should operator of mongodb query.
        /// </summary>
        public const string ShouldOperator = "should";

        /// <summary>
        /// phrase operator of mongodb query.
        /// </summary>
        public const string QueryOperator = "query";

        /// <summary>
        /// phrase operator of mongodb query.
        /// </summary>
        public const string PathOperator = "path";

        /// <summary>
        /// index key of mongodb query.
        /// </summary>
        public const string IndexKey = "index";

        /// <summary>
        /// atlas default index value of mongodb query.
        /// </summary>
        public const string DefaultIndexvalue = "default";

        /// <summary>
        /// atlas autoComplete index value of mongodb query.
        /// </summary>
        public const string AutoCompleteIndexvalue = "autocomplete";
    }
}
