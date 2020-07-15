using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Business.Abstract
{
    public interface IService<TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task<TEntity> GetByIdAsync(int Id);
        void Delete(TEntity entity);
        void Delete(object EntityId);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
    }
}
