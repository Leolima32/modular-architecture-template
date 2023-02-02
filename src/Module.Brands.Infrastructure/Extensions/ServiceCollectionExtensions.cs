using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Brands.Core.Abstractions;
using Module.Brands.Infrastructure.Persistence;
using Module.Brands.Infrastructure.Repositories;
using Shared.Infrastructure.Extensions;

namespace Module.Brands.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBrandInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDatabaseContext<BrandDbContext>(config)
                .AddScoped<IBrandDbContext>(provider => provider.GetService<BrandDbContext>())
                .AddTransient<IBrandRepository, BrandRepository>();

            var context = services.BuildServiceProvider().GetService<BrandDbContext>();
            context.Database.Migrate();
            return services;
        }
    }
}
