using PublicSchool.Application.Model.RequestResponse;
using PublicSchool.Domain.Entities;

namespace PublicSchool.Domain.Services.Mappers
{
    public static class GradeServiceMapper
    {
        public static GradeRequestResponse ConvertToResponse(this Grade grade)
        {
            return new GradeRequestResponse
            {
                Id = grade.Id,
                Description = grade.Description,
                SchoolId = grade.SchoolId,
                SchoolName = grade.School.Name
            };
        }

        internal static Grade ConvertToGrade(GradeRequestResponse gradeRequest)
        {
            return new Grade
            {
                Id = gradeRequest.Id,
                Description = gradeRequest.Description,
                SchoolId = gradeRequest.SchoolId
            };
        }

        internal static Grade ConvertRequestToGrade(GradeRequest gradeRequest)
        {
            return new Grade
            {
                Description = gradeRequest.Description,
                SchoolId = gradeRequest.SchoolId
            };
        }
    }
}