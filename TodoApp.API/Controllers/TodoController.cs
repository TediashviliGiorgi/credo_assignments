using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public TodoController(
            UserManager<UserEntity> userManager,
            ITodoRepository todoRepository)
        {
            _userManager = userManager;
            _todoRepository = todoRepository;
        }

        [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTodoRequest request)
        {
            var user = await _userManager.GetUserAsync(User);
            
            if (user == null)
            {
                return NotFound("User not found");
            }

            var userId = user.Id;
            await _todoRepository.InsertAsync(userId, request.Title, request.Description, request.Deadline);
            await _todoRepository.SaveChangesAsync();
            return Ok();
        }

        [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
        [HttpGet("get-by-deadline")]
        public async Task<IActionResult> GetByDeadline()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            if (user == null)
            {
                return NotFound("User not found");
            }

            var todos = await  _todoRepository.GetTodosByDeadlineAsync(userId);
           
            return Ok(todos);
        }


        [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
        [HttpPost("search")]
        public async Task<IActionResult> GetBySearch([FromBody] SearchTodoRequest request) 
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            if (user == null)
            {
                return NotFound("User not found");
            }

            var filtredTodos = await _todoRepository.SearchAsync(userId,  request);
            return Ok(filtredTodos);
        }

        [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
        [HttpPatch("update-by-id")]
        public async Task<IActionResult> Update([FromBody]UpdateTodoRequest request)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            if(user == null)
            {
                return NotFound();
            }
            await _todoRepository.UpdateTodoAsync(userId, request);
            await _todoRepository.SaveChangesAsync();
            return Ok();
        }

        [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
        [HttpPost("UpdateToDoStatus")]
        public async Task<IActionResult> ChangeToDoStatus(UpdateTodoStatusRequest request)
        {
            var user = _userManager.GetUserAsync(User);

            if (user == null)
            {
                return null;
            }

            await _todoRepository.ChangeTodoStatus(request);
            await _todoRepository.SaveChangesAsync();
            return Ok();
        }

        // [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
        //[HttpPost("change-status-by-id")]

    }
}
