using Microsoft.EntityFrameworkCore;
using TodoApp.API.DB;
using TodoApp.API.DB.Entities;

namespace TodoApp.API.Repositories
{
    public interface ITodoRepository
    {
        Task InsertAsync(int userId, string title, string description, DateTime deadline);
        Task SaveChangesAsync();

        Task <List<TodoEntity>> GetTodosByDeadlineAsync(int userId);
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

        //public List<TodoEntity> Search(string filter, int pageSize, int pageIndex) 
        //{
        //    var allTodos = _db.Todos
        //        .Where(t => t.UserId == 1)
        //        .Where(t => t.Title == filter)
        //        .Skip(pageIndex * pageSize)
        //        .Take(pageSize)
        //        .OrderBy(t => t.CreatedAt)
        //        .ToList();

        //    return allTodos;
        //}

        public async Task <List<TodoEntity>> GetTodosByDeadlineAsync(int userId)
        {
            var todos = await _db.Todos
                .OrderBy(t => t.Deadline)
                .ToListAsync();
            return  todos;
           
        }


        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
