using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Categories.Core.Extensions;
using Module.Categories.Infrastructure.Extensions;

namespace Module.Categories
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddCategoryModule(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddCategoryCore()
                .AddCategoryInfrastructure(configuration);
            return services;
        }
    }
}
