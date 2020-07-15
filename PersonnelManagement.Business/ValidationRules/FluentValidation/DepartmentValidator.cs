using FluentValidation;
using PersonnelManagement.EntityFramework.Concrate;
using PersonnelManagement.EntityFramework.Concrate.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.Business.ValidationRules.FluentValidation
{
    public class DepartmentValidator:AbstractValidator<DepartmentDto>
    {
        public DepartmentValidator()
        {
            RuleFor(d => d.Name).NotEmpty();
            RuleFor(d => d.DepartmentId).GreaterThan(0);
        }
    }
}
