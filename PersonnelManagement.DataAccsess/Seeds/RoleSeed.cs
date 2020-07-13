using FakerDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagement.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.DataAccsess.Seeds
{
    public class RoleSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            for (int i = 1; i < 7; i++)
            {
                builder.HasData(new Role { RoleId = i, Name = Faker.Name.Name(),CreatedOn=Faker.Date.Backward(365),ModifiedOn=Faker.Date.Backward(365) });
            }

        }
    }
}
