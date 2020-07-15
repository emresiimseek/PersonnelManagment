using FrameworkCore.Abstract;
using Microsoft.EntityFrameworkCore;
using PersonnelManagement.DataAccsess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FrameworkCore.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext _dbContext;
        private DepartmentRepository _department { get; set; }
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDepartmentRepository Department => _department = _department ?? new DepartmentRepository(_dbContext);

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
                await _dbContext.SaveChangesAsync();
        }
    }
}
