namespace TodoApp.API.Models.Requests
{
    public class UpdateTodoStatusRequest
    {
        public int TodoId { get; set; } 
        public int TodoStatus { get; set; }
    }
}
