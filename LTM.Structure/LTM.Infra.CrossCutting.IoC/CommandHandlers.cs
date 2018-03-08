using LTM.Domain.Commands.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Infra.CrossCutting.IoC
{
    internal class CommandHandlers
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ProductCommandHandler, ProductCommandHandler>();
            services.AddTransient<UserCommandHandler, UserCommandHandler>();
        }
    }
}
