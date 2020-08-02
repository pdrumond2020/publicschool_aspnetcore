using PublicSchool.Domain.Entities;
using PublicSchool.Domain.Interface.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSchool.Domain.Interface.Repositories
{
    public interface ISchoolRepository : IRepository<School>
    {
    }
}