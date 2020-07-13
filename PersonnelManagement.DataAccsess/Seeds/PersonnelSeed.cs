using FakerDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagement.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.DataAccsess.Seeds
{
    public class PersonnelSeed : IEntityTypeConfiguration<Personnel>
    {
        public void Configure(EntityTypeBuilder<Personnel> builder)
        {
            
            for (int i = 1; i < 10; i++)
            {
                Random random = new Random();
                Random randomjob = new Random();
                builder.HasData(new Personnel { PersonnelId = i,
                    Name = Faker.Name.FirstName(),
                    LastName = Faker.Name.LastName(),
                    Salary = 2500.15m*i,
                    CreatedOn=Faker.Date.Backward(365),
                    ModifiedOn=Faker.Date.Backward(365),
                    DateOfRecuitment=Faker.Date.Backward(365),
                    EmploymentendDate=Faker.Date.Backward(365),
                    DepartmentId=random.Next(1,5),
                    JobId= randomjob.Next(1,7),
                });

            }
        }
    }
}
