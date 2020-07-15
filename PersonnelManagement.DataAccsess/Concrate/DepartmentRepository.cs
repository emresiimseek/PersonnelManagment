using FrameworkCore.Abstract;
using FrameworkCore.Concrate;
using Microsoft.EntityFrameworkCore;
using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.DataAccsess.Concrate
{
    public class DepartmentRepository : EntityRepositoryBase<Department>, IDepartmentRepository
    {
        private MyContext myContext { get => _dbContext as MyContext; }
        public DepartmentRepository(DbContext context) : base(context)
        {
        }
        public async Task<List<Department>> GetAllDepartmentWithChild()
        {
            return await myContext.Departments.Include(i => i.Personnels).ThenInclude(it => it.Job).ToListAsync();
        }
    }
}
