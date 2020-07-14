using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Abstract
{
    public interface IRepository<TEntity>
        where TEntity:class
    {
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task<TEntity> GetByIdAsync(int Id);
        void Delete(TEntity entity);
        void Delete(object EntityId);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

    }
}
