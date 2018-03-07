using LTM.Infra.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace LTM.Infra.Data
{
    public class ProductRepository : Repository
    {
        public ProductRepository(IUnitOfWork uow, DbContext context) : base(uow, context)
        {
        }
    }
}
