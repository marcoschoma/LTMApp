using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LTM.Domain.Commands.Input;
using LTM.Domain.Commands.Input.Product;
using LTM.Domain.Commands.Results;
using LTM.Domain.Entities;
using LTM.Domain.Repositories;
using LTM.Infra;

namespace LTM.Domain.Commands.Handlers
{
    public class ProductCommandHandler
    {
        private IProductRepository _repository;

        public ProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<NotificationResult> InsertAsync(InsertProductCommand insertProductCommand)
        {
            var product = new ProductInfo(insertProductCommand);
            return await _repository.InsertAsync(product);
        }

        //public async Task<IEnumerable<ProductWithPriceCommandResult>> GetAllProductWithPriceAsync()
        //{
        //    return await _repository.GetAllProductWithPriceAsync();
        //}
    }
}
