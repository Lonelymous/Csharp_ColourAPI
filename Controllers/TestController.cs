using Microsoft.AspNetCore.Mvc;

namespace DockerAPI.Controllers
{
    [ApiController]
    [Route("/test")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Server is working.";
        }
    }

}