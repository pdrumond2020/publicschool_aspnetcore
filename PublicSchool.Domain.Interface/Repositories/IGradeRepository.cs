using PublicSchool.Domain.Entities;
using PublicSchool.Domain.Interface.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicSchool.Domain.Interface.Repositories
{
    public interface IGradeRepository : IRepository<Grade>
    {
        Task<IEnumerable<Grade>> ListJoinSchoolAsync();

        Task<Grade> FindJoinSchoolAsync(int id);
    }
}