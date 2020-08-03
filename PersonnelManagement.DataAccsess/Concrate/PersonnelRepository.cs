using FrameworkCore.Abstract;
using FrameworkCore.Concrate;
using Microsoft.EntityFrameworkCore;
using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.DataAccsess.Concrate
{
    public class PersonnelRepository: EntityRepositoryBase<Personnel>, IPersonnelRepository
    {
        private MyContext myContext { get => _dbContext as MyContext; }
        public PersonnelRepository(DbContext context) : base(context)
        {
        }

        public async Task<Personnel> GetPersonnel(Expression<Func<Personnel, bool>> filter)
        {
            return await myContext.Set<Personnel>().SingleOrDefaultAsync(filter);
        }
    }
}
