using LTM.Domain.Commands.Results;
using LTM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Domain.Repositories
{
    public interface IProductRepository : IRepository<ProductInfo>
    {
        Task<IEnumerable<ProductCommandResult>> GetAsync();
    }
}
