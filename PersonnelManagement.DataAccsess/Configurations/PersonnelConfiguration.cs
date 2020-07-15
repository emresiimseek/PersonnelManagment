using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.DataAccsess.Configurations
{
    public class PersonnelConfiguration : IEntityTypeConfiguration<Personnel>
    {
        public void Configure(EntityTypeBuilder<Personnel> builder)
        {
            builder.HasKey(p => p.PersonnelId);
            builder.Property(p => p.PersonnelId).UseIdentityColumn();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(200);
            builder.Property(p => p.EmploymentendDate).IsRequired().HasColumnType("datetime");
            builder.Property(p => p.DateOfRecuitment).IsRequired().HasColumnType("datetime");
            builder.Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime");
            builder.Property(p => p.ModifiedOn).IsRequired().HasColumnType("datetime");
            builder.Property(p => p.Salary).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
