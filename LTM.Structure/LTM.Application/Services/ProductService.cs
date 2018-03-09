using LTM.Domain;
using LTM.Domain.Commands;
using LTM.Domain.Commands.Handlers;
using LTM.Domain.Commands.Input;
using LTM.Domain.Commands.Input.Product;
using LTM.Domain.Commands.Results;
using LTM.Domain.Repositories;
using LTM.Domain.Services;
using LTM.Infra;
using LTM.Infra.Data.Base;
using LTM.Infra.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Application.Services
{
    public class ProductService : ApplicationService, IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ProductCommandHandler _handler;

        public ProductService(IUnitOfWork uow, IProductRepository repository, ProductCommandHandler handler) : base(uow)
        {
            _repository = repository;
            _handler = handler;
        }

        public async Task<IEnumerable<ProductCommandResult>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProductCommandResult> GetAsync(int idProduct)
        {
            return await _repository.GetAsync(idProduct);
        }

        public async Task<IEnumerable<ProductWithPriceCommandResult>> GetWithPrice(DateTime refereceDate)
        {
            return await _repository.GetAllProductWithPriceAsync(refereceDate);
        }

        public async Task<NotificationResult> InsertAsync(InsertProductCommand insertProductCommand)
        {
            BeginTransaction();
            var result = await _handler.InsertAsync(insertProductCommand);
            return Commit(result);
        }
    }
}
