using LTM.Domain.Commands.Handlers;
using LTM.Domain.Commands.Input;
using LTM.Infra;
using LTM.Infra.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace LTM.StartupConfig
{
    public class LTMSeed
    {
        private UserCommandHandler _userHandler;
        private ProductCommandHandler _productHandler;
        private LTMDataContext _context;

        public LTMSeed(IServiceCollection services)
        {
            IServiceProvider provider = services.BuildServiceProvider();

            _context = provider.GetService<LTMDataContext>();
            _userHandler = provider.GetService<UserCommandHandler>();
            _productHandler = provider.GetService<ProductCommandHandler>();
        }

        public async void EnsureSeedData()
        {
            if(!_context.User.Any()) {
                await _userHandler.InsertAsync(new InsertUserCommand()
                {
                    FirstName = "Administrator",
                    Username = "admin",
                    Password = Cryptography.Hash("admin"),
                    Email = "admin@ltm.com.br"
                });
            }

            if(!_context.Product.Any())
            {
                await _productHandler.InsertAsync(new InsertProductCommand()
                {
                    Description = "First Product"
                });
                await _productHandler.InsertAsync(new InsertProductCommand()
                {
                    Description = "Second Product"
                });
                await _productHandler.InsertAsync(new InsertProductCommand()
                {
                    Description = "Third Product"
                });
                await _productHandler.InsertAsync(new InsertProductCommand()
                {
                    Description = "Fourth Product"
                });
                await _productHandler.InsertAsync(new InsertProductCommand()
                {
                    Description = "Fifth Product"
                });
            }
        }
    }
}
