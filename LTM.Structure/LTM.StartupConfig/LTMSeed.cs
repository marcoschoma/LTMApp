using LTM.Domain.Commands.Handlers;
using LTM.Domain.Commands.Input;
using LTM.Domain.Commands.Input.Product;
using LTM.Domain.Commands.Input.ProductPrice;
using LTM.Domain.Commands.Input.User;
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
        private ProductPriceCommandHandler _productPriceHandler;
        private LTMDataContext _context;

        public LTMSeed(IServiceCollection services)
        {
            IServiceProvider provider = services.BuildServiceProvider();

            _context = provider.GetService<LTMDataContext>();
            _userHandler = provider.GetService<UserCommandHandler>();
            _productHandler = provider.GetService<ProductCommandHandler>();
            _productPriceHandler = provider.GetService<ProductPriceCommandHandler>();
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
            if (!_context.ProductPrice.Any())
            {
                await _productPriceHandler.InsertAsync(new InsertProductPriceCommand()
                {
                    IdProduct = 1,
                    EndDate = new DateTime(2018, 01, 01),
                    Value = 90
                });
                await _productPriceHandler.InsertAsync(new InsertProductPriceCommand()
                {
                    IdProduct = 1,
                    EndDate = null,
                    Value = 100
                });

                await _productPriceHandler.InsertAsync(new InsertProductPriceCommand()
                {
                    IdProduct = 2,
                    EndDate = new DateTime(2018, 01, 01),
                    Value = 180
                });
                await _productPriceHandler.InsertAsync(new InsertProductPriceCommand()
                {
                    IdProduct = 2,
                    EndDate = null,
                    Value = 200
                });

                await _productPriceHandler.InsertAsync(new InsertProductPriceCommand()
                {
                    IdProduct = 3,
                    EndDate = null,
                    Value = 300
                });

                await _productPriceHandler.InsertAsync(new InsertProductPriceCommand()
                {
                    IdProduct = 4,
                    EndDate = null,
                    Value = 400
                });

                await _productPriceHandler.InsertAsync(new InsertProductPriceCommand()
                {
                    IdProduct = 5,
                    EndDate = null,
                    Value = 500
                });
            }
        }
    }
}
