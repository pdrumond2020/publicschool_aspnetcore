using PublicSchool.Application.Model.RequestResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublicSchool.Domain.Interface.Services
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolRequestResponse>> ListAsync();

        Task<SchoolRequestResponse> ListByIdAsync(int id);

        Task<int> InsertAsync(SchoolRequest schoolRequest);

        Task<int> RemoveAsync(int id);

        Task<SchoolRequestResponse> UpdateAsync(SchoolRequestResponse schoolRequest, int id);
    }
}