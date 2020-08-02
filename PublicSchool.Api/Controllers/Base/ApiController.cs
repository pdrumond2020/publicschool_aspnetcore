using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace PublicSchool.Api.Controllers.Base
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected ApiController()
        {
        }

        protected new Task<IActionResult> Response(HttpStatusCode statusCode, object result = null)
        {
            if (result != null)
            {
                return Task.FromResult<IActionResult>(StatusCode((int)statusCode, result));
            }
            else
            {
                return Task.FromResult<IActionResult>(StatusCode((int)statusCode));
            }
        }
    }
}