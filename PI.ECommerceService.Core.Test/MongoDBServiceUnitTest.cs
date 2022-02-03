using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;
using MongoDB.Driver.Core.Connections;
using MongoDB.Driver.Core.Servers;
using Moq;
using Newtonsoft.Json.Linq;
using PI.ECommerceService.Core.Configuration;
using PI.ECommerceService.Core.Service;
using PI.ECommerceService.Models.Constants;
using PI.ECommerceService.Models.MongoDB;
using Xunit;

namespace PI.ECommerceService.Core.Test
{
    public class MongoDBServiceUnitTest
    {
        private MongoDBSettings settings;
        private Mock<IMongoClient> mongoClient;
        private Mock<IMongoDatabase> mongodb;
        private Mock<IMongoCollection<Products>> productCollection;
        private List<Products> productList;
        private Products product;
        private Mock<IAsyncCursor<Products>> productCursor;

        public MongoDBServiceUnitTest()
        {
            this.settings = new MongoDBSettings("ecommerce-db");
            this.mongoClient = new Mock<IMongoClient>();
            this.productCollection = new Mock<IMongoCollection<Products>>();
            this.mongodb = new Mock<IMongoDatabase>();
            this.productCursor = new Mock<IAsyncCursor<Products>>();

            this.product = new Products
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
            };

            this.productList = new List<Products>()
            {
                this.product
            };
        }

        [Fact]
        public async Task GetProductsByFreeTextSearch()
        {
            this.InitializeMongoProductCollection();

            var mongoDBService = new MongoDBService(this.settings, this.mongoClient.Object);

            var response = await mongoDBService.GetProductsByFreeTextSearch("test");

            ValidateProductsData(response[0], this.product);
        }

        [Fact]
        public async Task GetProducts()
        {
            this.InitializeMongoProductCollection();

            var mongoDBService = new MongoDBService(this.settings, this.mongoClient.Object);

            var response = await mongoDBService.GetProducts(
                new Models.DTO.Request.SearchRequestDTO()
                {
                    Department = "any",
                    Categories = new List<string>() { "any" },
                    AttributeFilter = new List<Models.DTO.Request.AttributeFilterDTO>()
                    {
                        new Models.DTO.Request.AttributeFilterDTO()
                        {
                            K = "size",
                            V = "3"
                        }
                    }
                });

            ValidateProductsData(response[0], this.product);
        }

        private static void ValidateProductsData(Products products, Products mockProduct)
        {
            Assert.Equal(mockProduct.Id, products.Id);
            Assert.Equal(mockProduct.Department, products.Department);
            Assert.Equal(mockProduct.Description, products.Description);
            Assert.Equal(mockProduct.Item, products.Item);
            Assert.Equal(mockProduct.Sku, products.Sku);
            Assert.Equal(mockProduct.Quantity, products.Quantity);
            Assert.Equal(mockProduct.Image, products.Image);
            Assert.Equal(mockProduct.InsertedDate, products.InsertedDate);
            Assert.Equal(mockProduct.UpdatedDate, products.UpdatedDate);
            Assert.Equal(mockProduct.SchemaVersion, products.SchemaVersion);
            Assert.Equal(mockProduct.Attributes, products.Attributes);
            Assert.Equal(mockProduct.Categories, products.Categories);
            Assert.Equal(mockProduct.ManufactureDetails, products.ManufactureDetails);
            Assert.Equal(mockProduct.Pricing, products.Pricing);
            Assert.Equal(mockProduct.Rating, products.Rating);
        }

        private void InitializeMongoProductCollection()
        {
            this.productCursor.Setup(_ => _.Current).Returns(this.productList);

            this.productCursor
                .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true).Returns(false);

            this.productCursor
                .SetupSequence(_ => _.MoveNextAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true)).Returns(Task.FromResult(false));

            this.productCollection.Setup(x => x.AggregateAsync(
                It.IsAny<PipelineDefinition<Products, Products>>(),
                It.IsAny<AggregateOptions>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(this.productCursor.Object);

            this.InitializeMongoDb();
        }

        private void InitializeMongoDb()
        {
            this.mongodb.Setup(x => x.GetCollection<Products>(MongoDBConstants.ProductCollectionName, default))
                .Returns(this.productCollection.Object);

            this.mongoClient.Setup(x => x.GetDatabase(It.IsAny<string>(), default))
                .Returns(this.mongodb.Object);
        }
    }
}
