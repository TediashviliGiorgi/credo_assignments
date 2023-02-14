using TodoApp.API.DB;
using TodoApp.API.DB.Entities;

namespace TodoApp.API.Repositories
{
    public interface ITodoRepository
    {
        Task InsertAsync(int userId, string title, string description, DateTime deadline);
        Task SaveChangesAsync();
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
            entity.UserId = entity.UserId;
            entity.Title = entity.Title;
            entity.Description = entity.Description;
            entity.Deadline = entity.Deadline;
            entity.TodoStatus = entity.TodoStatus;
            entity.CreatedAt = DateTime.UtcNow;
        
            await _db.Todos.AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
