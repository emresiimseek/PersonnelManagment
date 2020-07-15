using FakerDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.DataAccsess.Seeds
{
    public class JobSeed : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            for (int i = 1; i < 7; i++)
            {
                builder.HasData(new Job { JobId = i, Name = Faker.Team.Name(), CreatedOn = Faker.Date.Backward(365),ModifiedOn=Faker.Date.Backward(365)});
            }

        }
    }
}
