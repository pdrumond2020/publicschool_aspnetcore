using PublicSchool.Domain.Interface.Repositories;
using System;
using System.Threading.Tasks;

namespace PublicSchool.Domain.Interface.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISchoolRepository SchoolRepository { get; }
        IGradeRepository GradeRepository { get; }

        Task CommitAsync();

        void BeginTransaction();

        void RollbackTransaction();
    }
}