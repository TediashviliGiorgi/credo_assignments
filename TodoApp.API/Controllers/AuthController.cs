using Microsoft.AspNetCore.Mvc;

namespace TodoApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase 
    {
        [HttpGet]
        public string Ping()
        {
            return "Pong";
        }
    }
}
