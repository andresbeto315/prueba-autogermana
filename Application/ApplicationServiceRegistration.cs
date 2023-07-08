using Application.Services;
using Domain.Contracts.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>()
                    .AddTransient<IProductService, ProductService>();
            return services;
        }
    }
}