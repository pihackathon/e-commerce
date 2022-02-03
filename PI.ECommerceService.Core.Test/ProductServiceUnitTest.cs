using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using PI.ECommerceService.Core.Interfaces;
using PI.ECommerceService.Core.Service;
using PI.ECommerceService.Models.DTO.Product;
using PI.ECommerceService.Models.DTO.Request;
using PI.ECommerceService.Models.MongoDB;
using Xunit;

namespace PI.ECommerceService.Core.Test
{
    public class ProductServiceUnitTest
    {
        private Mock<IMongoDBService> mongoDBService;
        private List<Products> products;
        private IMapper mapper;

        public ProductServiceUnitTest()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
            this.mapper = new Mapper(configuration);
            this.mongoDBService = new Mock<IMongoDBService>();
            this.products = new List<Products>()
            {
                new Products()
            {
                Id = "1",
                Attributes = new Dictionary<string, string>()
                {
                    { "ram", "4gb" },
                    { "diskSpace", "128gb" }
                },
                Categories = new List<string>() { "Mobiles" },
                Department = "Electronics",
                Description = "Brand new affordable samsung mobile",
                Item = "Samsung Galaxy M31s",
                Sku = "sku1234567",
                Quantity = 99,
                Image = "url",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                SchemaVersion = 1,
                ManufactureDetails = new ManufactureDetails()
                {
                    Brand = "Samsung",
                    Model = "M31s"
                },
                Pricing = new Pricing()
                {
                    Price = 15000,
                    Currency = "INR",
                    Discount = 1000,
                    DiscountExpireAt = DateTime.UtcNow.AddDays(10)
                },
                Rating = new Rating()
                {
                    AggregateRating = 4.3,
                    TotalReviews = 10000,
                    Stars = new List<int>() { 1, 2, 3, 4, 5 }
                }
            }
            };
        }

        [Fact]
        public async Task GetProductsByFreeTextSearch()
        {
            this.mongoDBService.Setup(x => x.GetProductsByFreeTextSearch(It.IsAny<string>()))
                .Returns(Task.FromResult<List<Products>>(this.products));

            var productService = new ProductService(this.mongoDBService.Object, this.mapper);

            var response = await productService.GetProductsByFreeTextSearch(It.IsAny<string>());

            Assert.Single(response);
        }

        [Fact]
        public async Task GetProducts()
        {
            this.mongoDBService.Setup(x => x.GetProducts(It.IsAny<SearchRequestDTO>()))
                .Returns(Task.FromResult<List<Products>>(this.products));

            var productService = new ProductService(this.mongoDBService.Object, this.mapper);

            var response = await productService.GetProducts(It.IsAny<SearchRequestDTO>());

            Assert.Single(response);
        }

        private static void ValidateProductDtoData(ProductDTO products, Products mockProduct)
        {
            Assert.Equal(mockProduct.Id, products.Id);
            Assert.Equal(mockProduct.Department, products.Department);
            Assert.Equal(mockProduct.Description, products.Description);
            Assert.Equal(mockProduct.Item, products.Item);
            Assert.Equal(mockProduct.Sku, products.Sku);
            Assert.Equal(mockProduct.Quantity, products.Quantity);
            Assert.Equal(mockProduct.Image, products.Image);
            Assert.Equal(mockProduct.Attributes, products.Attributes);
            Assert.Equal(mockProduct.Categories, products.Categories);
            Assert.Equal(mockProduct.ManufactureDetails.Brand, products.ManufactureDetails.Brand);
            Assert.Equal(mockProduct.ManufactureDetails.Model, products.ManufactureDetails.Model);
            Assert.Equal(mockProduct.Pricing.Currency, products.Pricing.Currency);
            Assert.Equal(mockProduct.Pricing.Discount, products.Pricing.Discount);
            Assert.Equal(mockProduct.Pricing.DiscountExpireAt, products.Pricing.DiscountExpireAt);
            Assert.Equal(mockProduct.Pricing.Price, products.Pricing.Price);
            Assert.Equal(mockProduct.Rating.AggregateRating, products.Rating.AggregateRating);
            Assert.Equal(mockProduct.Rating.Stars, products.Rating.Stars);
            Assert.Equal(mockProduct.Rating.TotalReviews, products.Rating.TotalReviews);
        }
    }
}
