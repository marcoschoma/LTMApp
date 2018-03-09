using LTM.Domain.Entities;
using LTM.Infra.Data.Base;
using LTM.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace LTM.Infra.Data.Contexts
{
    public class LTMDataContext : DbContext
    {
        private DbConnection _conn;

        public LTMDataContext(IUnitOfWork uow)
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conn);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            RegisterMaps(builder);
        }

        public static void RegisterMaps(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new ProductPriceMap());
        }

        public DbSet<UserInfo> User { get; set; }
        public DbSet<ProductInfo> Product { get; set; }
        public DbSet<ProductPriceInfo> ProductPrice { get; set; }
    }
}
