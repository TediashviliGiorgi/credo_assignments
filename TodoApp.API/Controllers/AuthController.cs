using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TodoApp.API.Auth;
using TodoApp.API.DB;
using TodoApp.API.DB.Entities;
using TodoApp.API.Models.Requests;
using TodoApp.API.Repositories;

namespace TodoApp.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private TokenGenerator _tokenGenerator;
        private UserManager<UserEntity> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ISendEmailRequestRepository _sendEmailRequestRepository;

        public AuthController(IConfiguration configuration, ISendEmailRequestRepository sendEmailRequestRepository, UserManager<UserEntity> userManager, TokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _sendEmailRequestRepository = sendEmailRequestRepository;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        } 
         
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var entity = new UserEntity();
            entity.UserName = request.Email;
            entity.Email = request.Email;
            var result = await _userManager.CreateAsync(entity, request.Password);

            if(!result.Succeeded)
            {
                var firstError = result.Errors.First();
                return BadRequest(firstError.Description);
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(entity);

            return Ok();
        }

        [HttpPost("login")]
        public async Task <IActionResult> Login([FromBody]LoginRequest request)
        {
            //Check user credentials
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var isCorrectPassword = await  _userManager.CheckPasswordAsync(user, request.Password);

            if (!isCorrectPassword)
            {
                return BadRequest("Invalid email or password");
            }

            return Ok(_tokenGenerator.Generate(request.Email));
        }
        
        [HttpPost("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordResetRequest request)
        {
            // find user
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return NotFound("User not found");
            }
           
            // Generate password reset token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // insert email into SendEmailRequest table
            var sendEmailRequestEntity = new SendEmailRequestEntity();
            sendEmailRequestEntity.ToAddress = request.Email;
            sendEmailRequestEntity.SendEmailRequestStatus = (int)SendEmailRequestStatus.New;
            sendEmailRequestEntity.CreatedAt = DateTime.Now;
            sendEmailRequestEntity.Body = $"Hello, Your password reset link is: <a>www.example.domain{token}</a>";

            _sendEmailRequestRepository.Equals(sendEmailRequestEntity);
            await _sendEmailRequestRepository.SaveChangesAsync();
            // Return Result
            return Ok();
        }

        //ResetPassword
        //1. Validate token
        //2. Validate new password
        //3. Reset password
        //4.Return Result

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            //request.userId
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            //request.Token
            //request.NewPassword
            if(user == null)
            {
                return NotFound();
            }
            var resetResult = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);
            if (!resetResult.Succeeded)
            {
                var firstError = resetResult.Errors.First();
                return StatusCode(500, firstError.Description);
            }
            return Ok();
        }
    }
}
