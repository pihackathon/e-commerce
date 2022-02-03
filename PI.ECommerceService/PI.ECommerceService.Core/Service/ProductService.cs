using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PI.ECommerceService.Core.Interfaces;
using PI.ECommerceService.Models.DTO.Product;
using PI.ECommerceService.Models.DTO.Request;

namespace PI.ECommerceService.Core.Service
{
    public class ProductService : IProductService
    {
        private readonly IMongoDBService mongoDBService;
        private readonly IMapper mapper;

        public ProductService(IMongoDBService mongoDBService, IMapper mapper)
        {
            this.mongoDBService = mongoDBService;
            this.mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetProducts(SearchRequestDTO searchRequestDTO)
        {
            try
            {
                var products = await this.mongoDBService.GetProducts(searchRequestDTO);

                return this.mapper.Map<List<ProductDTO>>(products);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ProductDTO>> GetProductsByFreeTextSearch(string searchText)
        {
            try
            {
                var products = await this.mongoDBService.GetProductsByFreeTextSearch(searchText);

                return this.mapper.Map<List<ProductDTO>>(products);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
