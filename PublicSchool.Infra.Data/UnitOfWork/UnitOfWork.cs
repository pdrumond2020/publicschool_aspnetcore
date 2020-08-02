using Microsoft.EntityFrameworkCore.Storage;
using PublicSchool.Domain.Interface.Repositories;
using PublicSchool.Domain.Interface.UnitOfWork;
using PublicSchool.Infra.Data.Context;
using PublicSchool.Infra.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace PublicSchool.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PublicSchoolContext _publicSchoolContext;

        private bool _usesDatabaseTransaction;
        private IDbContextTransaction _dbContextTransaction;

        public UnitOfWork()
        {
            _publicSchoolContext = new PublicSchoolContext();
        }

        public ISchoolRepository SchoolRepository => new SchoolRepository(_publicSchoolContext);

        public IGradeRepository GradeRepository => new GradeRepository(_publicSchoolContext);

        public void BeginTransaction()
        {
            _usesDatabaseTransaction = true;
            _dbContextTransaction = _publicSchoolContext.Database.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            await _publicSchoolContext.SaveChangesAsync();
            if (_usesDatabaseTransaction && _dbContextTransaction != null)
            {
                _dbContextTransaction.Commit();
            }
        }

        public void RollbackTransaction()
        {
            if (_usesDatabaseTransaction && _dbContextTransaction != null)
            {
                _usesDatabaseTransaction = false;
                _dbContextTransaction.Rollback();
            }
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _publicSchoolContext.Dispose();
                _dbContextTransaction.Dispose();
            }
            disposedValue = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}