using LTM.Domain.Commands;
using LTM.Domain.Commands.Input;
using LTM.Domain.Commands.Input.Product;
using LTM.Domain.Commands.Results;
using LTM.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Domain.Services
{
    public interface IProductService
    {
        Task<NotificationResult> InsertAsync(InsertProductCommand insertProductCommand);

        Task<ProductCommandResult> GetAsync(int idProduct);
        Task<IEnumerable<ProductCommandResult>> GetAllAsync();
        Task<IEnumerable<ProductWithPriceCommandResult>> GetWithPrice(DateTime today);
    }
}
