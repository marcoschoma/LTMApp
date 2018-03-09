using LTM.Domain.Commands.Results;
using LTM.Domain.Entities;
using LTM.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Domain.Repositories
{
    public interface IProductRepository : IRepository<ProductInfo>
    {
        Task<ProductCommandResult> GetAsync(int idProduct);
        Task<IEnumerable<ProductCommandResult>> GetAllAsync();
        Task<NotificationResult> InsertAsync(ProductInfo product);
        Task<IEnumerable<ProductWithPriceCommandResult>> GetAllProductWithPriceAsync(DateTime referenceDate);
    }
}
