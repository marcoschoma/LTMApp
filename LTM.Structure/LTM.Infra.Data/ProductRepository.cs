using LTM.Domain.Commands.Results;
using LTM.Domain.Entities;
using LTM.Domain.Repositories;
using LTM.Domain.Specs;
using LTM.Infra.Data.Base;
using LTM.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTM.Infra.Data
{
    public class ProductRepository : Repository, IProductRepository
    {
        private readonly LTMDataContext _context;

        public ProductRepository(IUnitOfWork uow, LTMDataContext context) : base(uow, context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCommandResult>> GetAsync()
        {
            return await _context.Product.AsNoTracking()
                .Select(ProductSpecs.AsProductCommandResult)
                .ToListAsync();
        }

        public async Task<NotificationResult> InsertAsync(ProductInfo product)
        {
            var result = new NotificationResult();
            try
            {
                await _context.Product.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
                throw;
            }
            return result;
        }
    }
}
