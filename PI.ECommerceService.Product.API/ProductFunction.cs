using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PI.ECommerceService.Core.Interfaces;
using PI.ECommerceService.Models.Constants;
using PI.ECommerceService.Models.DTO.Request;
using PI.ECommerceService.Models.ErrorMessage;

namespace PI.ECommerceService.Product.API
{
    public class ProductFunction
    {
        private IProductService productService;

        public ProductFunction(IProductService productService)
        {
            this.productService = productService;
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Errors), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(Errors), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Errors), (int)HttpStatusCode.InternalServerError)]
        [FunctionName("GetProducts")]
        public async Task<IActionResult> GetProducts(
            [HttpTrigger(AuthorizationLevel.Anonymous, "Post", Route = "api/v1/product")] 
            [RequestBodyType(typeof(SearchRequestDTO), "filters")] HttpRequest request, ILogger log)
        {
            try
            {
                SearchRequestDTO filter;

                using (var streamReader = new StreamReader(request.Body))
                {
                    filter = JsonConvert.DeserializeObject<SearchRequestDTO>(await streamReader.ReadToEndAsync());
                }

                log.LogInformation(JsonConvert.SerializeObject(filter));

                var result = await this.productService.GetProducts(filter);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                var error = new Errors()
                {
                    Code = ErrorConstants.InternalServerErrorCode,
                    Message = ErrorConstants.InternalServerError
                };

                return new BadRequestObjectResult(error);
            }
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Errors), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(Errors), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Errors), (int)HttpStatusCode.InternalServerError)]
        [FunctionName("GetProductsByFreeTextSearch")]
        [QueryStringParameter("search", "this is the search text", DataType = typeof(string), Required = false)]
        public async Task<IActionResult> GetProductsByFreeTextSearch(
            [HttpTrigger(AuthorizationLevel.Anonymous, "Get", Route = "api/v1/products/search")]
            HttpRequest request, ILogger log)
        {
            try
            {
                string filter = request.Query["search"];

                var result = await this.productService.GetProductsByFreeTextSearch(filter);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                var error = new Errors()
                {
                    Code = ErrorConstants.InternalServerErrorCode,
                    Message = ErrorConstants.InternalServerError
                };

                return new BadRequestObjectResult(error);
            }
        }
    }
}
