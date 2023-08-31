using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YuGiOhApi.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccessController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}