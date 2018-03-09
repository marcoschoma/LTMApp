using LTM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Infra.Data.Mappings
{
    public class ProductPriceMap : IEntityTypeConfiguration<ProductPriceInfo>
    {
        public void Configure(EntityTypeBuilder<ProductPriceInfo> builder)
        {
            builder.Property(x => x.IdProduct).IsRequired();
            builder.Property(x => x.Value).IsRequired();

            builder.HasKey(x => x.IdProductPrice);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductPrices).HasForeignKey(x => x.IdProduct).OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("ProductPrice");
        }
    }
}
