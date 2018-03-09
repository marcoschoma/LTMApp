using LTM.Domain.Commands.Results;
using LTM.Domain.Entities;
using LTM.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Domain.Repositories
{
    public interface IProductPriceRepository
    {
        Task<NotificationResult> InsertAsync(ProductPriceInfo productPrice);
        Task<NotificationResult> UpdateAsync(ProductPriceInfo productPrice);

        Task<IEnumerable<ProductPriceCommandResult>> GetAllAsync();
        Task<IEnumerable<ProductPriceCommandResult>> GetByProductIdAsync(int idProduct);
    }
}
