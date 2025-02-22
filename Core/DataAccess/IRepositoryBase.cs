using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetById<T>(T id);
        Task<TEntity> GetByIdAsync<T>(T id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate, bool tracking = true);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true);
        List<TEntity> GetAll(bool tracking, Expression<Func<TEntity, bool>>? expression = null);
        Task<List<TEntity>> GetAllAsync(bool tracking, Expression<Func<TEntity, bool>>? expression = null);
    }
}
