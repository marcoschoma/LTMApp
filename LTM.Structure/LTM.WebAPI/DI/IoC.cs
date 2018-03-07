using LTM.Infra.CrossCutting.IoC;
using LTM.Infra.Data.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTM.WebAPI.DI
{
    public sealed class IoC
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            DboIoC.Register(services);
        }
    }
}
