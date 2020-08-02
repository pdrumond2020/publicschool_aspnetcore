using PublicSchool.Application.Interface;
using PublicSchool.Application.Model.RequestResponse;
using PublicSchool.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PublicSchool.Application.Implementation
{
    public class SchoolAppService : ISchoolAppService
    {
        private readonly ISchoolService _schoolService;

        public SchoolAppService(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        public async Task<MessageResponse<IEnumerable<SchoolRequestResponse>>> ListAsync()
        {
            var messageResponse = new MessageResponse<IEnumerable<SchoolRequestResponse>>();

            try
            {
                messageResponse.IsSuccess = true;
                messageResponse.StatusCode = HttpStatusCode.OK;
                messageResponse.Data = await _schoolService.ListAsync();
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

        public async Task<MessageResponse<SchoolRequestResponse>> ListAsync(int id)
        {
            var messageResponse = new MessageResponse<SchoolRequestResponse>();

            try
            {
                messageResponse.IsSuccess = true;
                messageResponse.StatusCode = HttpStatusCode.OK;
                messageResponse.Data = await _schoolService.ListByIdAsync(id);
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

        public async Task<MessageResponse<SchoolRequestResponse>> InsertAsync(SchoolRequest schoolRequest)
        {
            var messageResponse = new MessageResponse<SchoolRequestResponse>();

            try
            {
                var result = await _schoolService.InsertAsync(schoolRequest);
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

        public async Task<MessageResponse<SchoolRequestResponse>> RemoveAsync(int id)
        {
            var messageResponse = new MessageResponse<SchoolRequestResponse>();

            try
            {
                var result = await _schoolService.RemoveAsync(id);
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

        public async Task<MessageResponse<SchoolRequestResponse>> UpdateAsync(SchoolRequestResponse schoolRequest, int id)
        {
            var messageResponse = new MessageResponse<SchoolRequestResponse>();

            try
            {
                var result = await _schoolService.UpdateAsync(schoolRequest, id);
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