using LTM.Domain.Commands.Handlers;
using LTM.Domain.Commands.Input;
using LTM.Infra.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LTM.StartupConfig
{
    public class LTMSeed
    {
        private UserCommandHandler _userHandler;
        private LTMDataContext _context;

        public LTMSeed(IServiceCollection services)
        {
            IServiceProvider provider = services.BuildServiceProvider();

            _context = provider.GetService<LTMDataContext>();
            _userHandler = provider.GetService<UserCommandHandler>();
        }

        public void EnsureSeedData()
        {
            var userCommand = new InsertUserCommand()
            {
                FirstName = "Administrator",
                Username = "admin",
                Password = "admin",
                Email = "admin@ltm.com.br"
            };

            _userHandler.InsertAsync(userCommand);
        }
    }
}
