using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Infra.Data.Base
{
    public abstract class Repository
    {
        private readonly IUnitOfWork _uow;
        private readonly DbContext _context;

        public Repository(IUnitOfWork uow, DbContext context)
        {
            this._uow = uow;
            this._context = context;
        }

        public void UseTransaction()
        {
            _context.Database.UseTransaction(_uow.Transaction);
        }
    }
}
