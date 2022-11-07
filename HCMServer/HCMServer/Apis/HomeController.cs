using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCMServer.Apis.V1.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok("All set");
        }
    }
}
