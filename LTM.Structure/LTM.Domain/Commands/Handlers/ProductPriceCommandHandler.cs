using LTM.Domain.Commands.Input.ProductPrice;
using LTM.Domain.Entities;
using LTM.Domain.Repositories;
using LTM.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Domain.Commands.Handlers
{
    public class ProductPriceCommandHandler
    {
        private IProductPriceRepository _repository;

        public ProductPriceCommandHandler(IProductPriceRepository repository)
        {
            _repository = repository;
        }

        public async Task<NotificationResult> InsertAsync(InsertProductPriceCommand insertProductCommand)
        {
            var productPrice = new ProductPriceInfo(insertProductCommand);

            return await _repository.InsertAsync(productPrice);
        }
    }
}
