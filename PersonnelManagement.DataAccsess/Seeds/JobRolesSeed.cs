using FakerDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.DataAccsess.Seeds
{
    public class JobRolesSeed : IEntityTypeConfiguration<JobRoles>
    {
        public void Configure(EntityTypeBuilder<JobRoles> builder)
        {
            Random random = new Random(); 
            for (int i = 1; i < 7; i++)
            {

                builder.HasData(new JobRoles { Id = i, JobId = i, RoleId = random.Next(1, 7), CreatedOn = Faker.Date.Backward(365), ModifiedOn = Faker.Date.Backward(365) });
            }
        }
    }
}
