using Eshop.Application.Repositories;
using Eshop.Application.Services;
using Eshop.Persistence.ConnectionFactory;
using Eshop.Persistence.Repositories;
using Eshop.Persistence.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DbConnectionFactory>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStorageService, StorageService>();
        }
    }
}
