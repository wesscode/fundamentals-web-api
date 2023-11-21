using Microsoft.AspNetCore.Mvc;

namespace ApiFuncional.Controllers
{
    [ApiController]
    [Route("api/conta")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Registrar()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Login()
        {
            return Ok();
        }
    }
}
