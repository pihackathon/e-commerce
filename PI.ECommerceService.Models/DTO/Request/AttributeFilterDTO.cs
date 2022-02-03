namespace PI.ECommerceService.Models.DTO.Request
{
    /// <summary>
    /// Attribute filter for the products to be searched for.
    /// </summary>
    public class AttributeFilterDTO
    {
        /// <summary>
        /// Gets or sets key of the search parameter.
        /// </summary>
        public string K { get; set; }

        /// <summary>
        /// Gets or sets value of the search parameter.
        /// </summary>
        public string V { get; set; }
    }
}
