using PublicSchool.Application.Model.RequestResponse;
using PublicSchool.Domain.Entities;
using System;

namespace PublicSchool.Domain.Services.Mappers
{
    public static class SchoolServiceMapper
    {
        internal static SchoolRequestResponse ConvertToResponse(this School school)
        {
            return new SchoolRequestResponse { Id = school.Id, Name = school.Name };
        }

        internal static School ConvertToSchool(SchoolRequestResponse schoolRequest)
        {
            return new School
            {
                Id = schoolRequest.Id,
                Name = schoolRequest.Name
            };
        }

        internal static School ConvertRequestToSchool(SchoolRequest schoolRequest)
        {
            return new School
            {
                Name = schoolRequest.Name
            };
        }
    }
}