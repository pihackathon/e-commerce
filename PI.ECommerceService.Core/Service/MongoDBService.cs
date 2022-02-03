using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Bson;
using MongoDB.Driver;
using PI.ECommerceService.Core.Configuration;
using PI.ECommerceService.Core.Interfaces;
using PI.ECommerceService.Models.Constants;
using PI.ECommerceService.Models.DTO.Request;
using PI.ECommerceService.Models.MongoDB;

namespace PI.ECommerceService.Core.Service
{
    public class MongoDBService : IMongoDBService
    {
        private readonly IMongoCollection<Products> productCollection;
        
        public MongoDBService(MongoDBSettings settings, IMongoClient mongoClient)
        {
            var mongoDB = mongoClient.GetDatabase(settings.DbName);
            this.productCollection = mongoDB.GetCollection<Products>(MongoDBConstants.ProductCollectionName);
        }

        public async Task<List<Products>> GetProducts(SearchRequestDTO searchRequestDTO)
        {
            var departmentfilter = new BsonDocument
                    {
                       { MongoDBConstants.QueryOperator, searchRequestDTO.Department },
                       { MongoDBConstants.PathOperator, ProductInfoConstants.Department }
                    };

            var categories = new BsonArray();
            categories.AddRange(searchRequestDTO.Categories);

            var categoryFilter = new BsonDocument
                    {
                       { MongoDBConstants.QueryOperator, categories },
                       { MongoDBConstants.PathOperator, ProductInfoConstants.Categories }
                    };

            var must = new BsonArray();

            must.Add(new BsonDocument { { MongoDBConstants.PhraseOperator, departmentfilter } });
            must.Add(new BsonDocument { { MongoDBConstants.PhraseOperator, categoryFilter } });

            foreach (var attribute in searchRequestDTO.AttributeFilter)
            {
                string path = string.Empty;
                ProductInfoConstants.Attributes.TryGetValue(attribute.K, out path);

                var attributefilter = new BsonDocument
                    {
                       { MongoDBConstants.QueryOperator, attribute.V },
                       { MongoDBConstants.PathOperator, path }
                    };

                must.Add(new BsonDocument { { MongoDBConstants.PhraseOperator, attributefilter } });
            }

            var compound = new BsonDocument
                {
                    { MongoDBConstants.MustOperator, must }
                };

            var search = new BsonDocument
                {
                    { MongoDBConstants.IndexKey, MongoDBConstants.DefaultIndexvalue },
                    { MongoDBConstants.CompoundOperator, compound }
                };

            var searchStage = new BsonDocument
                {
                    { MongoDBConstants.SearchOperator, search }
                };

            var pipeline = new[] { searchStage };

            var result = await this.productCollection.AggregateAsync<Products>(pipeline);

            return await result.ToListAsync();
        }

        public async Task<List<Products>> GetProductsByFreeTextSearch(string searchText)
        {
            var pathToBeSearched = new[]
            {
                    ProductInfoConstants.Department, ProductInfoConstants.Item, ProductInfoConstants.Description,
                    ProductInfoConstants.Category0, ProductInfoConstants.Category1, ProductInfoConstants.Category2
                };

            var should = new BsonArray();

            foreach (var path in pathToBeSearched)
            {
                var filter = new BsonDocument
                    {
                       { MongoDBConstants.QueryOperator, searchText },
                       { MongoDBConstants.PathOperator, path }
                    };

                should.Add(new BsonDocument { { MongoDBConstants.AutoCompleteOperator, filter } });
            }

            var compound = new BsonDocument
                {
                    { MongoDBConstants.ShouldOperator, should },
                    { "minimumShouldMatch", 1 }
                };

            var search = new BsonDocument
                {
                    { MongoDBConstants.IndexKey, MongoDBConstants.AutoCompleteIndexvalue },
                    { MongoDBConstants.CompoundOperator, compound }
                };

            var searchStage = new BsonDocument
                {
                    { MongoDBConstants.SearchOperator, search }
                };

            var pipeline = new[] { searchStage };

            var result = await this.productCollection.AggregateAsync<Products>(pipeline);

            return await result.ToListAsync();
        }
    }
}