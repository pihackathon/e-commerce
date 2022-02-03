using System.Reflection;
using AzureFunctions.Extensions.Swashbuckle;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PI.ECommerceService.Core.Configuration;
using PI.ECommerceService.Product.API;

[assembly: FunctionsStartup(typeof(PI.ECommerceService.Criteria.API.Startup))]

namespace PI.ECommerceService.Criteria.API
{
    public class Startup : IWebJobsStartup
    {
        public static void Configure(IFunctionsHostBuilder builder)
        {
            ServicesDI.LoadSettings(builder);

            ServicesDI.MongoClientInjection(builder);

            ServicesDI.APIServicesInjection(builder);
        }

        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddSwashBuckle(Assembly.GetExecutingAssembly(), c =>
            {
                c.ConfigureSwaggerGen = d => d.DocumentFilter<SwashBuckleDocumentFilter>();
            });
            Configure(new FunctionHostBuilder(builder.Services));
        }
    }
}