using FrameworkCore.Abstract;
using Microsoft.EntityFrameworkCore;
using PersonnelManagement.EntityFramework.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Concrete
{
    public class EntityRepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
        public readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public EntityRepositoryBase(DbContext dbContext)
        {

            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
             await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {

            return await _dbSet.FindAsync(Id);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(object EntityId)
        {
            TEntity entityToDelete = _dbSet.Find(EntityId);
            Delete(entityToDelete);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.SingleOrDefaultAsync(filter);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ?
                 _dbSet :
                 _dbSet.Where(filter);
        }
    }
}
