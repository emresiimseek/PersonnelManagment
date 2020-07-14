using FrameworkCore.Abstract;
using PersonnelManagement.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Business.Abstract
{
    public interface IDepartmentService
    {
        Task AddAsync(Department department);
    }
}
