using PublicSchool.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicSchool.Domain.Interface.Services
{
    public interface IGradeService
    {
        Task<IEnumerable<GradeRequestResponse>> ListAsync();

        Task<GradeRequestResponse> ListAsync(int id);

        Task<IEnumerable<GradeRequestResponse>> ListBySchoolAsync(int schoolId);

        Task<int> InsertAsync(GradeRequest gradeRequest);

        Task<int> RemoveAsync(int id);

        Task<GradeRequestResponse> UpdateAsync(GradeRequestResponse schoolRequest, int id);
    }
}