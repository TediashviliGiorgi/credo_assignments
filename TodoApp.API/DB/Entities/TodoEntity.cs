namespace TodoApp.API.DB.Entities
{
    public enum TodoStatus
    {
        New = 1,
        Done = 2,
        Canceled =3
    }

    public class TodoEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set;}
        public int TodoStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}
