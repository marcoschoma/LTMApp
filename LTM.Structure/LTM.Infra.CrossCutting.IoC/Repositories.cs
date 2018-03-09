using LTM.Domain.Repositories;
using LTM.Infra.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Infra.CrossCutting.IoC
{
    internal class Repositories
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductPriceRepository, ProductPriceRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
