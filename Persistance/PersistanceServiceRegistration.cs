using Domain.Base;
using Domain.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories;

namespace Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<DBContextAutogermana>(options => options.UseSqlServer(Config.Instance().ConnectionString));
            services.AddTransient<ICategoryRepository, CategoryRepository>()
                    .AddTransient<IProductRepository, ProductRepository>();
            return services;
        }
    }
}