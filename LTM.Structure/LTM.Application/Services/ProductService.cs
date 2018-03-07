using LTM.Domain;
using LTM.Domain.Commands;
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
        //protected readonly IUnitOfWork _uow;
        //private NotificationResult result;

        private readonly IProductRepository _repository;

        public Task<IEnumerable<ProductCommandResult>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
