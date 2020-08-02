using PublicSchool.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicSchool.Application.Interface
{
    public interface IGradeAppService
    {
        Task<MessageResponse<IEnumerable<GradeRequestResponse>>> ListAsync();

        Task<MessageResponse<GradeRequestResponse>> ListAsync(int id);

        Task<MessageResponse<GradeRequestResponse>> InsertAsync(GradeRequest gradeRequest);

        Task<MessageResponse<GradeRequestResponse>> RemoveAsync(int id);

        Task<MessageResponse<GradeRequestResponse>> UpdateAsync(GradeRequestResponse gradeRequest, int id);
    }
}