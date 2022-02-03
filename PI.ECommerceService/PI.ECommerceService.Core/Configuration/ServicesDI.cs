using System;
using AutoMapper;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PI.ECommerceService.Core.Interfaces;
using PI.ECommerceService.Core.Service;

namespace PI.ECommerceService.Core.Configuration
{
    public static class ServicesDI
    {
        public static void LoadSettings(this IFunctionsHostBuilder functionBuilder)
        {
            functionBuilder.Services.AddAutoMapper(typeof(ServicesDI));

            var mongoDBSetting = new MongoDBSettings(
               Environment.GetEnvironmentVariable("MongoDbName"));

            functionBuilder.Services.AddSingleton<MongoDBSettings>(mongoDBSetting);
        }

        public static void MongoClientInjection(this IFunctionsHostBuilder functionBuilder)
        {
            functionBuilder.Services.AddSingleton<IMongoClient, MongoClient>(x =>
            {
                var uri = Environment.GetEnvironmentVariable("MongoDbConnectionString");
                return new MongoClient(uri);
            });

            functionBuilder.Services.AddSingleton<IMongoDBService, MongoDBService>();
        }

        public static void APIServicesInjection(this IFunctionsHostBuilder functionBuilder)
        {
            functionBuilder.Services.AddSingleton<IProductService, ProductService>();
        }
    }
}
