namespace MovieDatabase.API.Models.Requests.MovieRequests
{
    public class UpdateMovieRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public DateTime Release { get; set; }
    }
}
