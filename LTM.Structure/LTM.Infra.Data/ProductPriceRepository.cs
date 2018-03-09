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
using System.Text;
using System.Threading.Tasks;

namespace LTM.Infra.Data
{
    public class ProductPriceRepository : Repository, IProductPriceRepository
    {
        private readonly LTMDataContext _context;

        public ProductPriceRepository(IUnitOfWork uow, LTMDataContext context) : base(uow, context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductPriceCommandResult>> GetAllAsync()
        {
            return await _context.ProductPrice.AsNoTracking()
                .Select(ProductPriceSpecs.AsProductPriceCommandResult)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductPriceCommandResult>> GetByProductIdAsync(int idProduct)
        {
            return await _context.ProductPrice.AsNoTracking()
                .Where(pp => pp.IdProduct == idProduct)
                .Select(ProductPriceSpecs.AsProductPriceCommandResult)
                .ToListAsync();
        }
        
        public async Task<NotificationResult> InsertAsync(ProductPriceInfo productPrice)
        {
            var result = new NotificationResult();

            try
            {
                await _context.ProductPrice.AddAsync(productPrice);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }
            return result;
        }

        public async Task<NotificationResult> UpdateAsync(ProductPriceInfo productPrice)
        {
            var result = new NotificationResult();

            try
            {
                _context.ProductPrice.Attach(productPrice);
                _context.Entry(productPrice).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }
            return result;
        }
    }
}
