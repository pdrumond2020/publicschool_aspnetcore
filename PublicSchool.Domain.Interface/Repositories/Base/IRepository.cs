using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PublicSchool.Domain.Interface.Repositories.Base
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> filter);

        Task<int> AddAsync(TEntity obj);

        //Task<int> UpdateAsync(TEntity obj);
        Task<TEntity> UpdateAsyn(TEntity t, object key);

        Task<int> DeleteAsync(TEntity entity);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);
    }
}