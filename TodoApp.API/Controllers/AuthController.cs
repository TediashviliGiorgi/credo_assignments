using Microsoft.AspNetCore.Mvc;
using TodoApp.API.Auth;

namespace TodoApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private TokenGenerator _tokenGenerator;

        public AuthController(TokenGenerator tokenGenerator)
        {
            _tokenGenerator= tokenGenerator;
        }

        [HttpGet]
        public string Ping()
        {
            return "pong";
        }

        [HttpPost("login/{email}")]
        public string Login(string email)
        {
      
            return _tokenGenerator.Generate(email);
        }

    }
}
