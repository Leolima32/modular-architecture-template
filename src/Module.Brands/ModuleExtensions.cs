using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Brands.Core.Extensions;
using Module.Brands.Infrastructure.Extensions;

namespace Module.Brands
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddBrandModule(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddBrandCore()
                .AddBrandInfrastructure(configuration);
            return services;
        }
    }
}
