using Microsoft.Extensions.DependencyInjection;
using System;

namespace LTM.Infra.CrossCutting.IoC
{
    public class DboIoC
    {
        public static void Register(IServiceCollection services)
        {
            Repositories.Register(services);
            ApplicationServices.Register(services);
            CommandHandlers.Register(services);
        }
    }
}
