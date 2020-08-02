using Microsoft.AspNetCore.Mvc;
using PublicSchool.Api.Controllers.Base;
using PublicSchool.Application.Interface;
using PublicSchool.Application.Model.RequestResponse;
using System.Threading.Tasks;

namespace PublicSchool.Api.Controllers
{
    [ApiController]
    [Route("v1/school")]
    public class SchoolController : ApiController
    {
        private readonly ISchoolAppService _schoolAppService;

        public SchoolController(ISchoolAppService schoolAppService)
        {
            _schoolAppService = schoolAppService;
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> Get()
        {
            var result = _schoolAppService.ListAsync().Result;
            return Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> Get([FromRoute] int id)
        {
            var result = _schoolAppService.ListAsync(id).Result;
            return Response(result.StatusCode, result);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> Add([FromBody] SchoolRequest schoolRequest)
        {
            var result = _schoolAppService.InsertAsync(schoolRequest).Result;
            return Response(result.StatusCode, result);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = _schoolAppService.RemoveAsync(id).Result;
            return Response(result.StatusCode, result);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> Update([FromBody] SchoolRequestResponse schoolRequest, [FromRoute] int id)
        {
            var result = _schoolAppService.UpdateAsync(schoolRequest, id).Result;
            return Response(result.StatusCode, result);
        }
    }
}