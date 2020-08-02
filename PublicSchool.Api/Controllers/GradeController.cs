using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PublicSchool.Api.Controllers.Base;
using PublicSchool.Application.Interface;
using PublicSchool.Application.Model.RequestResponse;

namespace PublicGrade.Api.Controllers
{
    [ApiController]
    [Route("v1/grade")]
    public class GradeController : ApiController
    {
        private readonly IGradeAppService _GradeAppService;

        public GradeController(IGradeAppService GradeAppService)
        {
            _GradeAppService = GradeAppService;
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> Get()
        {
            var result = _GradeAppService.ListAsync().Result;
            return Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> Get([FromRoute] int id)
        {
            var result = _GradeAppService.ListAsync(id).Result;
            return Response(result.StatusCode, result);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> Add([FromBody] GradeRequest GradeRequest)
        {
            var result = _GradeAppService.InsertAsync(GradeRequest).Result;
            return Response(result.StatusCode, result);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = _GradeAppService.RemoveAsync(id).Result;
            return Response(result.StatusCode, result);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> Update([FromBody] GradeRequestResponse GradeRequest, [FromRoute] int id)
        {
            var result = _GradeAppService.UpdateAsync(GradeRequest, id).Result;
            return Response(result.StatusCode, result);
        }
    }
}