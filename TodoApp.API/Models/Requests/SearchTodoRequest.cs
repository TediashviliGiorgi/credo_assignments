namespace TodoApp.API.Models.Requests
{
    public class SearchTodoRequest
    {
        public string Filter { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
