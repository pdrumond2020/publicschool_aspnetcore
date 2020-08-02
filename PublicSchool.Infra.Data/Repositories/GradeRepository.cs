using Microsoft.EntityFrameworkCore;
using PublicSchool.Domain.Entities;
using PublicSchool.Domain.Interface.Repositories;
using PublicSchool.Infra.Data.Context;
using PublicSchool.Infra.Data.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicSchool.Infra.Data.Repositories
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        private readonly PublicSchoolContext _context;

        public GradeRepository(PublicSchoolContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grade>> ListJoinSchoolAsync()
        {
            return await _context.Grades.Include("School").ToListAsync();
        }

        public async Task<Grade> FindJoinSchoolAsync(int id)
        {
            return await _context.Grades.Include("School").Where(p => p.Id == id).FirstAsync();
        }
    }
}