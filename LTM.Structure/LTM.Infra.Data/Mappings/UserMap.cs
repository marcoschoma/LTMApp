using LTM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserInfo> builder)
        {
            builder.Property(x => x.IdUser).IsRequired();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.LastName).HasMaxLength(200);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).HasMaxLength(2000);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
            builder.HasAlternateKey(x => new { x.Username });
            builder.HasAlternateKey(x => new { x.Email });
            builder.HasKey(x => x.IdUser);

            builder.ToTable("User");
        }
    }
}
