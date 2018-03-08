using LTM.Infra.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LTM.Infra.CrossCutting.IoC
{
    public class LTMIoC
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<LTMDataContext, LTMDataContext>();
            Repositories.Register(services);
            ApplicationServices.Register(services);
            CommandHandlers.Register(services);
        }
    }
}
