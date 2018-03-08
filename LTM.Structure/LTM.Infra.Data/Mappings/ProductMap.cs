using LTM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Infra.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<ProductInfo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductInfo> builder)
        {
            builder.Property(x => x.IdProduct).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.HasKey(x => x.IdProduct);

            builder.ToTable("Product");
        }
    }
}