using FrameworkCore.Abstract;
using Microsoft.EntityFrameworkCore;
using PersonnelManagement.DataAccsess.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FrameworkCore.Concrate
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext _dbContext;
        private DepartmentRepository _department { get; set; }
        private PersonnelRepository _personnel { get; set; }
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDepartmentRepository Department => _department = _department ?? new DepartmentRepository(_dbContext);

        public IPersonnelRepository Personnel => _personnel = _personnel ?? new PersonnelRepository(_dbContext);

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
