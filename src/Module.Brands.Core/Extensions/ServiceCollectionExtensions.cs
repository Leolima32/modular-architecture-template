using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Module.Brands.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBrandCore(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
