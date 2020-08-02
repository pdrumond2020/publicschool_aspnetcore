using Microsoft.EntityFrameworkCore;
using PublicSchool.Domain.Interface.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PublicSchool.Infra.Data.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context) => _context = context;

        public Task<int> AddAsync(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            return _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsyn(TEntity entity, object key)
        {
            if (entity == null)
                return null;
            TEntity exist = await _context.Set<TEntity>().FindAsync(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            return exist;
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> filter) => await _context.Set<TEntity>().Where(filter).ToListAsync().ConfigureAwait(false);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter) => await _context.Set<TEntity>().FirstOrDefaultAsync(filter).ConfigureAwait(false);

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter) => await _context.Set<TEntity>().AnyAsync(filter).ConfigureAwait(false);

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.DisposeAsync();
                }

                disposedValue = true;
            }
        }

        ~Repository()
        {
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}