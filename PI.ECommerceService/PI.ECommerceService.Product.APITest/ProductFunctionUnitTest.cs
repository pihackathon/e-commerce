namespace PI.ECommerceService.Product.APITest
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Newtonsoft.Json;
    using PI.ECommerceService.Core.Interfaces;
    using PI.ECommerceService.Models.Constants;
    using PI.ECommerceService.Models.DTO.Product;
    using PI.ECommerceService.Models.DTO.Request;
    using PI.ECommerceService.Models.ErrorMessage;
    using PI.ECommerceService.Product.API;
    using Xunit;

#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    public class ProductFunctionUnitTest
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private Mock<IProductService> productService;
        private Mock<HttpRequest> request;
        private Mock<IQueryCollection> query;
        private Mock<ILogger> log;
        private MemoryStream memoryStream;
        private List<ProductDTO> products;

        public ProductFunctionUnitTest()
        {
            this.productService = new Mock<IProductService>();
            this.request = new Mock<HttpRequest>();
            this.log = new Mock<ILogger>();
            this.products = new List<ProductDTO>();
            this.query = new Mock<IQueryCollection>();
        }

        [Fact]
        public async Task GetProductsByFreeTextSearch()
        {
            var body = new object();
            var json = JsonConvert.SerializeObject(body);
            var byteArray = Encoding.ASCII.GetBytes(json);

            this.memoryStream = new MemoryStream(byteArray);
            this.memoryStream.Flush();
            this.memoryStream.Position = 0;

            this.productService.Setup(x => x.GetProductsByFreeTextSearch(It.IsAny<string>())).ReturnsAsync(this.products);
            this.request.Setup(x => x.Body).Returns(this.memoryStream);
            this.request.Setup(x => x.Query).Returns(this.query.Object);

            var apiFunction = new ProductFunction(this.productService.Object);

            var response = await apiFunction.GetProductsByFreeTextSearch(this.request.Object, this.log.Object);

            Assert.Equal(StatusCodes.Status200OK, ((OkObjectResult)response).StatusCode);
        }

        [Fact]
        public async Task GetProductsByFreeTextSearchError()
        {
            var body = new object();
            var json = JsonConvert.SerializeObject(body);
            var byteArray = Encoding.ASCII.GetBytes(json);

            this.memoryStream = new MemoryStream(byteArray);
            this.memoryStream.Flush();
            this.memoryStream.Position = 0;

            this.productService.Setup(x => x.GetProductsByFreeTextSearch(It.IsAny<string>())).Throws(new System.Exception("My exception"));
            this.request.Setup(x => x.Body).Returns(this.memoryStream);
            this.request.Setup(x => x.Query).Returns(this.query.Object);

            var apiFunction = new ProductFunction(this.productService.Object);

            var response = await apiFunction.GetProductsByFreeTextSearch(this.request.Object, this.log.Object);

            Assert.Equal(StatusCodes.Status400BadRequest, ((BadRequestObjectResult)response).StatusCode);
            Assert.Equal(ErrorConstants.InternalServerErrorCode, ((Errors)((BadRequestObjectResult)response).Value).Code);
            Assert.Equal(ErrorConstants.InternalServerError, ((Errors)((BadRequestObjectResult)response).Value).Message);
        }

        [Fact]
        public async Task GetProducts()
        {
            var body = new object();
            var json = JsonConvert.SerializeObject(body);
            var byteArray = Encoding.ASCII.GetBytes(json);

            this.memoryStream = new MemoryStream(byteArray);
            this.memoryStream.Flush();
            this.memoryStream.Position = 0;

            this.productService.Setup(x => x.GetProducts(It.IsAny<SearchRequestDTO>())).ReturnsAsync(this.products);
            this.request.Setup(x => x.Body).Returns(this.memoryStream);
            this.request.Setup(x => x.Query).Returns(this.query.Object);

            var apiFunction = new ProductFunction(this.productService.Object);

            var response = await apiFunction.GetProducts(this.request.Object, this.log.Object);

            Assert.Equal(StatusCodes.Status200OK, ((OkObjectResult)response).StatusCode);
        }

        [Fact]
        public async Task GetProductsError()
        {
            var body = new object();
            var json = JsonConvert.SerializeObject(body);
            var byteArray = Encoding.ASCII.GetBytes(json);

            this.memoryStream = new MemoryStream(byteArray);
            this.memoryStream.Flush();
            this.memoryStream.Position = 0;

            this.productService.Setup(x => x.GetProducts(It.IsAny<SearchRequestDTO>())).Throws(new System.Exception("My exception"));
            this.request.Setup(x => x.Body).Returns(this.memoryStream);
            this.request.Setup(x => x.Query).Returns(this.query.Object);

            var apiFunction = new ProductFunction(this.productService.Object);

            var response = await apiFunction.GetProducts(this.request.Object, this.log.Object);

            Assert.Equal(StatusCodes.Status400BadRequest, ((BadRequestObjectResult)response).StatusCode);
            Assert.Equal(ErrorConstants.InternalServerErrorCode, ((Errors)((BadRequestObjectResult)response).Value).Code);
            Assert.Equal(ErrorConstants.InternalServerError, ((Errors)((BadRequestObjectResult)response).Value).Message);
        }
    }
}
