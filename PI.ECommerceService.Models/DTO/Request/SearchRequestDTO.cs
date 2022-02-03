using System.Collections.Generic;

namespace PI.ECommerceService.Models.DTO.Request
{
    /// <summary>
    /// Request body with search parameter and value.
    /// </summary>
    public class SearchRequestDTO
    {
        /// <summary>
        /// Gets or sets all the attribute filters of the Products to be searched for.
        /// </summary>
        public List<AttributeFilterDTO> AttributeFilter { get; set; }

        /// <summary>
        /// Gets or sets the Department of the Products to be searched for.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the categories of the Products to be searched for.
        /// </summary>
        public List<string> Categories { get; set; }
    }
}
