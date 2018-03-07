using LTM.Domain.Commands.Results;
using LTM.Domain.Repositories;
using LTM.Infra.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTM.Infra.Data
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(IUnitOfWork uow, DbContext context) : base(uow, context)
        {
        }

        public Task<IEnumerable<ProductCommandResult>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
