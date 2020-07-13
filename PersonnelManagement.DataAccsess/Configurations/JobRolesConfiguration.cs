using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagement.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.DataAccsess.Configurations
{
    public class JobRolesConfiguration : IEntityTypeConfiguration<JobRoles>
    {
        public void Configure(EntityTypeBuilder<JobRoles> builder)
        {
            builder.HasKey(jr => jr.Id);
            builder.Property(jr => jr.Id).UseIdentityColumn();
            builder.Property(jr => jr.ModifiedOn).IsRequired().HasColumnType("datetime");
            builder.Property(jr => jr.CreatedOn).IsRequired().HasColumnType("datetime");

        }
    }
}
