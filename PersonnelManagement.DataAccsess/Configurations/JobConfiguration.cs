using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagement.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.DataAccsess.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(j => j.JobId);
            builder.Property(j => j.JobId).UseIdentityColumn();
            builder.Property(j => j.Name).IsRequired().HasMaxLength(150);
            builder.Property(j => j.CreatedOn).IsRequired().HasColumnType("datetime");
            builder.Property(j => j.ModifiedOn).IsRequired().HasColumnType("datetime");
        }
    }
}
