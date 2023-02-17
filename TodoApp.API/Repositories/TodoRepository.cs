using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using TodoApp.API.DB;
using TodoApp.API.DB.Entities;
using TodoApp.API.Models.Requests;

namespace TodoApp.API.Repositories
{
    public interface ITodoRepository
    {
        Task InsertAsync(int userId, string title, string description, DateTime deadline);
        Task SaveChangesAsync();

        Task<List<TodoEntity>> SearchAsync(int userId, SearchTodoRequest request);

        Task<List<TodoEntity>> GetTodosByDeadlineAsync(int userId);
        Task UpdateTodoAsync(int userId, UpdateTodoRequest request);

        Task ChangeTodoStatus(UpdateTodoStatusRequest request);
    }

    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _db;

        public TodoRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task InsertAsync(int userId, string title, string description, DateTime deadline)
        {
            var entity = new TodoEntity();
            entity.UserId = userId;
            entity.Title = title;
            entity.Description = description;
            entity.Deadline = deadline;
            entity.TodoStatus = entity.TodoStatus;
            entity.CreatedAt = DateTime.UtcNow;

            await _db.Todos.AddAsync(entity);
        }

        public async Task<List<TodoEntity>> SearchAsync(int userId, SearchTodoRequest request)
        {
            var filtredTodos = await _db.Todos
                .Where(t => t.UserId == userId)
                .Where(t => t.Title == request.Filter || t.Description == request.Filter) 
                //.Skip(request.PageIndex * request.PageSize)
                //.Take(request.PageSize)
                .OrderBy(t => t.CreatedAt)
                .ToListAsync();

            return filtredTodos;
        }

        public async Task UpdateTodoAsync(int userId, UpdateTodoRequest request)
        {
            var choisedTodo = await _db.Todos.FindAsync(request.TodoId);
            
            if (!string.IsNullOrEmpty(request.Title))
            {
                choisedTodo.Title = request.Title;
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                choisedTodo.Description = request.Description;
            }

            if (request.Deadline != null)
            {
                choisedTodo.Deadline = request.Deadline;
            }
        }

        public async Task<List<TodoEntity>> GetTodosByDeadlineAsync(int userId)
        {
            var todos = await _db.Todos
                .Where(u => u.UserId == userId)
                .OrderBy(t => t.Deadline)
                .ToListAsync();
            return todos;

        }

        public async Task ChangeTodoStatus(UpdateTodoStatusRequest request)
        {
            var choisedTodo = await _db.Todos.FindAsync(request.TodoId);

            choisedTodo.TodoStatus = request.TodoStatus;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
