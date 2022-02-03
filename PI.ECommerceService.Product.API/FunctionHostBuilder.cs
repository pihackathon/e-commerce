namespace PI.ECommerceService.Product.API
{
    using Microsoft.Azure.Functions.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;

    internal class FunctionHostBuilder : IFunctionsHostBuilder
    {
        public FunctionHostBuilder(IServiceCollection services)
        {
            this.Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
