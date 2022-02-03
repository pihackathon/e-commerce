using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PI.ECommerceService.Product.API
{
    public class SwashBuckleDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Info.Title = "ECommerce-Api";
            swaggerDoc.Info.Version = "v1";
            swaggerDoc.Info.Description = "Exposes API used for the Ecommerce Search.";
        }
    }
}
