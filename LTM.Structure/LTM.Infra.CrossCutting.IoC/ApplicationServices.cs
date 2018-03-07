using LTM.Application.Services;
using LTM.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Infra.CrossCutting.IoC
{
    internal class ApplicationServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
