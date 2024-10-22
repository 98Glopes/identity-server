using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leite.Api.Controllers
{
    [ApiController]
    [Route("api/leite")]
    public class LeiteController : ControllerBase
    {

        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            return Ok("Teste - GET");
        }
    }
}
