using PublicSchool.Application.Model.RequestResponse;
using PublicSchool.Domain.Interface.Services;
using PublicSchool.Domain.Interface.UnitOfWork;
using PublicSchool.Domain.Services.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicSchool.Domain.Services
{
    public class GradeService : IGradeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GradeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<GradeRequestResponse>> ListAsync()
        {
            var grades = _unitOfWork.GradeRepository.ListJoinSchoolAsync().Result;
            return Task.FromResult(grades.Select(grade => grade.ConvertToResponse()));
        }

        public Task<GradeRequestResponse> ListAsync(int id)
        {
            var grade = _unitOfWork.GradeRepository.FindJoinSchoolAsync(id).Result;
            return Task.FromResult(grade.ConvertToResponse());
        }

        public Task<IEnumerable<GradeRequestResponse>> ListBySchoolAsync(int schoolId)
        {
            var grades = _unitOfWork.GradeRepository.GetAllByAsync(grade => grade.SchoolId == schoolId).Result;
            return Task.FromResult(grades.Select(grade => grade.ConvertToResponse()));
        }

        public async Task<int> InsertAsync(GradeRequest gradeRequest)
        {
            var grade = GradeServiceMapper.ConvertRequestToGrade(gradeRequest);
            return await _unitOfWork.GradeRepository.AddAsync(grade).ConfigureAwait(false);
        }

        public async Task<int> RemoveAsync(int id)
        {
            var grade = _unitOfWork.GradeRepository.GetAsync(grade => grade.Id == id).Result;
            var result = await _unitOfWork.GradeRepository.DeleteAsync(grade).ConfigureAwait(false);

            return result;
        }

        public async Task<GradeRequestResponse> UpdateAsync(GradeRequestResponse gradeRequest, int id)
        {
            var grade = GradeServiceMapper.ConvertToGrade(gradeRequest);
            var gradeChanged = await _unitOfWork.GradeRepository.UpdateAsyn(grade, id).ConfigureAwait(false);
            return gradeChanged.ConvertToResponse();
        }
    }
}