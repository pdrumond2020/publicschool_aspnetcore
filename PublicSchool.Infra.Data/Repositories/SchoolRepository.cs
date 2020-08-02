using PublicSchool.Domain.Entities;
using PublicSchool.Domain.Interface.Repositories;
using PublicSchool.Infra.Data.Context;
using PublicSchool.Infra.Data.Repositories.Base;
using System;

namespace PublicSchool.Infra.Data.Repositories
{
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {
        public SchoolRepository(PublicSchoolContext context)
            : base(context)
        {
        }
    }
}