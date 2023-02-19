namespace MovieDatabase.API.DB.Entities
{
    public enum MovieStatus
    {
        Active,
        Deleted
    }
    public class MovieEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Release { get; set; }
        public string Director { get; set; }
        public MovieStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
