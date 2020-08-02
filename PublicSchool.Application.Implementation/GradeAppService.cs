using PublicSchool.Application.Interface;
using PublicSchool.Application.Model.RequestResponse;
using PublicSchool.Domain.Entities;
using PublicSchool.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PublicSchool.Application.Implementation
{
    public class GradeAppService : IGradeAppService
    {
        private readonly IGradeService _gradeService;
        private readonly ISchoolService _schoolService;

        public GradeAppService(IGradeService gradeService, ISchoolService schoolService)
        {
            _gradeService = gradeService;
            _schoolService = schoolService;
        }

        public async Task<MessageResponse<IEnumerable<GradeRequestResponse>>> ListAsync()
        {
            var messageResponse = new MessageResponse<IEnumerable<GradeRequestResponse>>();

            try
            {
                messageResponse.IsSuccess = true;
                messageResponse.StatusCode = HttpStatusCode.OK;
                messageResponse.Data = await _gradeService.ListAsync(); ;
                messageResponse.Message = "Listado com sucesso";
                messageResponse.Count = messageResponse.Data.Count();
            }
            catch (Exception e)
            {
                messageResponse.IsSuccess = false;
                messageResponse.Message = e.Message.ToString();
            }

            return messageResponse;
        }

        public async Task<MessageResponse<GradeRequestResponse>> ListAsync(int id)
        {
            var messageResponse = new MessageResponse<GradeRequestResponse>();

            try
            {
                messageResponse.IsSuccess = true;
                messageResponse.StatusCode = HttpStatusCode.OK;
                messageResponse.Data = await _gradeService.ListAsync(id); ;
                messageResponse.Message = "Listado com sucesso";
                messageResponse.Count = 1;
            }
            catch (Exception e)
            {
                messageResponse.IsSuccess = false;
                messageResponse.Message = e.Message.ToString();
            }

            return messageResponse;
        }

        public async Task<MessageResponse<GradeRequestResponse>> InsertAsync(GradeRequest gradeRequest)
        {
            var messageResponse = new MessageResponse<GradeRequestResponse>();

            try
            {
                var result = await _gradeService.InsertAsync(gradeRequest);
                messageResponse.IsSuccess = true;
                messageResponse.StatusCode = HttpStatusCode.OK;
                messageResponse.Message = "Inserido com sucesso";
                messageResponse.Count = result;
            }
            catch (Exception e)
            {
                messageResponse.IsSuccess = false;
                messageResponse.Message = e.Message.ToString();
            }

            return messageResponse;
        }

        public async Task<MessageResponse<GradeRequestResponse>> RemoveAsync(int id)
        {
            var messageResponse = new MessageResponse<GradeRequestResponse>();

            try
            {
                var result = await _gradeService.RemoveAsync(id);
                messageResponse.IsSuccess = true;
                messageResponse.StatusCode = HttpStatusCode.OK;
                messageResponse.Message = "Removido com sucesso";
                messageResponse.Count = result;
            }
            catch (Exception e)
            {
                messageResponse.IsSuccess = false;
                messageResponse.Message = e.Message.ToString();
            }

            return messageResponse;
        }

        public async Task<MessageResponse<GradeRequestResponse>> UpdateAsync(GradeRequestResponse schoolRequest, int id)
        {
            var messageResponse = new MessageResponse<GradeRequestResponse>();

            try
            {
                var result = await _gradeService.UpdateAsync(schoolRequest, id);
                messageResponse.IsSuccess = true;
                messageResponse.StatusCode = HttpStatusCode.OK;
                messageResponse.Message = "Alterado com sucesso";
                messageResponse.Data = result;
                messageResponse.Count = 1;
            }
            catch (Exception e)
            {
                messageResponse.IsSuccess = false;
                messageResponse.Message = e.Message.ToString();
            }

            return messageResponse;
        }
    }
}