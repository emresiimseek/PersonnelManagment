using FluentValidation;
using PersonnelManagement.EntityFramework.Concrate.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.Business.ValidationRules.FluentValidation
{
   public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentDto>
    {
        public UpdateDepartmentValidator()
        {
            RuleFor(d => d.DepartmentId).NotNull().GreaterThan(0);
            RuleFor(d => d.Name).NotNull();

        }
    }
}
