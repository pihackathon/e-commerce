using System.Collections.Generic;
using System.Threading.Tasks;
using PI.ECommerceService.Models.DTO.Product;
using PI.ECommerceService.Models.DTO.Request;

namespace PI.ECommerceService.Core.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Get products  filtered by the input search fields
        /// </summary>
        /// <param name="searchRequestDTO">filters</param>
        /// <returns>void</returns>
        Task<List<ProductDTO>> GetProducts(SearchRequestDTO searchRequestDTO);

        Task<List<ProductDTO>> GetProductsByFreeTextSearch(string searchText);
    }
}
