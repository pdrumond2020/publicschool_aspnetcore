using PublicSchool.Application.Model.RequestResponse;
using PublicSchool.Domain.Entities;
using PublicSchool.Domain.Interface.Repositories;
using PublicSchool.Domain.Interface.Services;
using PublicSchool.Domain.Interface.UnitOfWork;
using PublicSchool.Domain.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicSchool.Domain.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SchoolService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<SchoolRequestResponse>> ListAsync()
        {
            var schools = _unitOfWork.SchoolRepository.GetAllAsync().Result;
            return Task.FromResult(schools.Select(school => school.ConvertToResponse()));
        }

        public Task<SchoolRequestResponse> ListByIdAsync(int id)
        {
            var school = _unitOfWork.SchoolRepository.GetAsync(s => s.Id == id).Result;
            return Task.FromResult(school.ConvertToResponse());
        }

        public async Task<int> InsertAsync(SchoolRequest schoolRequest)
        {
            var school = SchoolServiceMapper.ConvertRequestToSchool(schoolRequest);
            return await _unitOfWork.SchoolRepository.AddAsync(school).ConfigureAwait(false);
        }

        public async Task<int> RemoveAsync(int id)
        {
            // Transactions are not supported by the in-memory store.
            //_unitOfWork.BeginTransaction();

            //try
            //{
            var grades = _unitOfWork.GradeRepository.GetAllByAsync(grade => grade.SchoolId == id);

            foreach (var grade in grades.Result)
            {
                await _unitOfWork.GradeRepository.DeleteAsync(grade);
            }

            var school = _unitOfWork.SchoolRepository.GetAsync(school => school.Id == id).Result;
            var result = await _unitOfWork.SchoolRepository.DeleteAsync(school).ConfigureAwait(false);

            //await _unitOfWork.CommitAsync();

            return result;
            //}
            //catch (Exception)
            //{
            //    _unitOfWork.RollbackTransaction();
            //    throw;
            //}
        }

        public async Task<SchoolRequestResponse> UpdateAsync(SchoolRequestResponse schoolRequest, int id)
        {
            var school = SchoolServiceMapper.ConvertToSchool(schoolRequest);
            var schoolChanged = await _unitOfWork.SchoolRepository.UpdateAsyn(school, id).ConfigureAwait(false);
            return schoolChanged.ConvertToResponse();
        }
    }
}