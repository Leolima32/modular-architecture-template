using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Categories.Core.Extensions;
using Module.Categories.Infrastructure.Extensions;
using Module.Products.Core.Extensions;
using Module.Products.Infrastructure.Extensions;

namespace Module.Products
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddProductModule(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddProductCore()
                .AddProductInfrastructure(configuration);
            return services;
        }
    }
}
