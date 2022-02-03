using System.Collections.Generic;
using System.Threading.Tasks;
using PI.ECommerceService.Models.DTO.Request;
using PI.ECommerceService.Models.MongoDB;

namespace PI.ECommerceService.Core.Interfaces
{
    public interface IMongoDBService
    {
        /// <summary>
        /// Gets list of products applying filter
        /// </summary>
        /// <param name="searchRequestDTO">search request filters for the products</param>
        /// <returns>Returns the products retrived</returns>
        Task<List<Products>> GetProducts(SearchRequestDTO searchRequestDTO);

        /// <summary>
        /// Gets list of products applying free text search
        /// </summary>
        /// <param name="searchText">search text for the products</param>
        /// <returns>Returns the products retrived</returns>
        Task<List<Products>> GetProductsByFreeTextSearch(string searchText);
    }
}
