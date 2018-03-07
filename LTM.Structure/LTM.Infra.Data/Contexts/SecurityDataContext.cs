using LTM.Domain.Entities;
using LTM.Infra.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace LTM.Infra.Data.Contexts
{
    public class SecurityDataContext : DbContext
    {
        private DbConnection _conn;

        public SecurityDataContext(IUnitOfWork uow)
        {
            _conn = uow.Connection;
            uow.AddContext(this);
            InitConfigurations();
        }

        public void InitConfigurations()
        {
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<UserInfo> User { get; set; }
    }
}
