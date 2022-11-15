using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Module.Products.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductCore(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
