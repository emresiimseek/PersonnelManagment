using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Abstract
{
    public interface IPersonnelRepository : IRepository<Personnel>
    {
        Task<Personnel> GetPersonnel(Expression<Func<Personnel, bool>> filter);
    }

}
