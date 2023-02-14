﻿namespace TodoApp.API.DB.Entities
{
    public enum TodoStatus
    {
        New,
        Done,
        Canceled
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
