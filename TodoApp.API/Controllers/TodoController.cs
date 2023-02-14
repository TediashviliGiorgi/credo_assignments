using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TodoApp.API.DB.Entities;
using TodoApp.API.Models.Requests;
using TodoApp.API.Repositories;

namespace TodoApp.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly ITodoRepository _todoRepository;
       

        public TodoController(UserManager<UserEntity> userManager, TodoRepository todoRepository)
        {
            _userManager = userManager;
            _todoRepository = todoRepository;
        }
         
        [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTodoRequest request)
        {
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                return NotFound("User not found");
            }
            var userId = user.Id;
            await _todoRepository.InsertAsync(userId, request.Title, request.Description, request.Deadline);
            await _todoRepository.SaveChangesAsync();
            return Ok();
        }
    }
}
