using Microsoft.AspNetCore.Identity;

namespace TodoApp.API.DB.Entities
{
    public class UserEntity : IdentityUser<int> 
    {
        public ICollection<TodoEntity> Todos { get; set; }
    }
}
