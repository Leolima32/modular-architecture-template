using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Categories.Core.Abstractions;
using Module.Categories.Infrastructure.Persistence;
using Module.Categories.Infrastructure.Repositories;
using Shared.Infrastructure.Extensions;

namespace Module.Categories.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCategoryInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDatabaseContext<CategoryDbContext>(config)
                .AddScoped<ICategoryDbContext>(provider => provider.GetService<CategoryDbContext>())
                .AddTransient<ICategoryRepository, CategoryRepository>();

            var context = services.BuildServiceProvider().GetService<CategoryDbContext>();
            context.Database.Migrate();
            return services;
        }
    }
}
