using LTM.Domain.Commands;
using LTM.Domain.Commands.Input;
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
        Task<IEnumerable<ProductCommandResult>> GetAsync();
        Task<NotificationResult> InsertAsync(InsertProductCommand insertProductCommand);
    }
}
