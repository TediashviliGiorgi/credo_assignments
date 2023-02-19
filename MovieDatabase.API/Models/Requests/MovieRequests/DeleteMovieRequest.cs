using MovieDatabase.API.DB.Entities;

namespace MovieDatabase.API.Models.Requests.MovieRequests
{
    public class DeleteMovieRequest
    {
        public int Id { get; set; }
        public MovieStatus status { get; set; }
    }
}
