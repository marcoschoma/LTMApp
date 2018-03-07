using LTM.Domain;
using LTM.Domain.Commands;
using LTM.Domain.Commands.Handlers;
using LTM.Domain.Commands.Results;
using LTM.Domain.Repositories;
using LTM.Domain.Services;
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

        public ProductService(IProductRepository repository, ProductCommandHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        public Task<IEnumerable<ProductCommandResult>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
