using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagement.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.DataAccsess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.RoleId);
            builder.Property(r => r.RoleId).UseIdentityColumn();
            builder.Property(r => r.Name).IsRequired().HasMaxLength(200);
            builder.Property(r => r.CreatedOn).IsRequired().HasColumnType("datetime");
            builder.Property(r => r.ModifiedOn).IsRequired().HasColumnType("datetime");
        }
    }
}
