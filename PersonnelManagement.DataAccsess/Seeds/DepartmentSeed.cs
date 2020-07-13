using FakerDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagement.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.DataAccsess.Seeds
{
    public class DepartmentSeed : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            for (int i = 1; i <= 5; i++)
            {
                builder.HasData(new Department { DepartmentId = i, Name = Faker.Company.Name(), CreatedOn = Faker.Date.Backward(365), ModifiedOn = Faker.Date.Backward(365), });
            }
        }
    }
}
