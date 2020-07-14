using FrameworkCore.Abstract;
using FrameworkCore.Concrete;
using Microsoft.EntityFrameworkCore;
using PersonnelManagement.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.DataAccsess.Concrete
{
    public class DepartmentRepository: EntityRepositoryBase<Department>, IDepartmentRepository
    {
        private MyContext myContext { get => _dbContext as MyContext; }
        public DepartmentRepository(DbContext context) : base(context)
        {
        }
    }
}
