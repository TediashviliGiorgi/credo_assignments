using MovieDatabase.API.DB.Entities;

namespace MovieDatabase.API.Models.Requests.MovieRequests
{
    public class AddMovieRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Release { get; set; }
        public string Director { get; set; }    
        public MovieStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
