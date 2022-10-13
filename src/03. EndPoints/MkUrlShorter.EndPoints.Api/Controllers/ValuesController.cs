using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MkUrlShorter.EndPoints.Api.Controllers
{
    [Route("api/Values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {

        }
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return new JsonResult("sss");
        }
    }
}
