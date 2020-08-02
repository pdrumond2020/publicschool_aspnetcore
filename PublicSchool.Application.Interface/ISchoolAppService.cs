using PublicSchool.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicSchool.Application.Interface
{
    public interface ISchoolAppService
    {
        Task<MessageResponse<IEnumerable<SchoolRequestResponse>>> ListAsync();

        Task<MessageResponse<SchoolRequestResponse>> ListAsync(int id);

        Task<MessageResponse<SchoolRequestResponse>> InsertAsync(SchoolRequest schoolRequest);

        Task<MessageResponse<SchoolRequestResponse>> RemoveAsync(int id);

        Task<MessageResponse<SchoolRequestResponse>> UpdateAsync(SchoolRequestResponse schoolRequest, int id);
    }
}