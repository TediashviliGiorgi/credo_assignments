namespace TodoApp.API.Models.Requests
{
    public class UpdateTodoRequest
    {
        public int TodoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
