using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagement.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.DataAccsess.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DepartmentId);
            builder.Property(d => d.DepartmentId).UseIdentityColumn();
            builder.Property(d => d.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime");
            builder.Property(p => p.ModifiedOn).IsRequired().HasColumnType("datetime");
            builder.ToTable("Department");

        }
    }
}
