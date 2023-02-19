using Microsoft.EntityFrameworkCore;
using MovieDatabase.API.DB;
using MovieDatabase.API.DB.Entities;
using MovieDatabase.API.Models.Requests.MovieRequests;

namespace MovieDatabase.API.Repsositories
{
    public interface IMovieRepository
    {
        Task SaveChangesAsync();

        Task AddMovieAsync(AddMovieRequest request);

        Task<MovieEntity> GetMovieAsync(int id);
        Task<List<MovieEntity>> SearchMovieAsync(SearchMovieRequest request);

        Task<MovieEntity> UpdateMovieAsync(UpdateMovieRequest request);
        Task DeleteMovieAsync(DeleteMovieRequest request);
    }

    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _db;

        public MovieRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddMovieAsync(AddMovieRequest request)
        {
            var movie = new MovieEntity();
            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.Status = request.Status;
            movie.Director = request.Director;
            movie.CreatedAt = DateTime.Now;

            await _db.AddAsync(movie);
        }

        public async Task<MovieEntity> GetMovieAsync(int id)
        {
            var movie = await _db.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null)
            {
                return null;
            }
            return movie;
        }

        public async Task<List<MovieEntity>> SearchMovieAsync(SearchMovieRequest request)
        {
            var movies = _db.Movies
           .Skip(request.PageSize * request.PageIndex)
           .Take(request.PageSize)
           .AsQueryable();

            return await movies
            .Select(m => new MovieEntity()
            {
                Title = m.Title,
                Description = m.Description,
                Status = m.Status,
                Release = m.Release,
                CreatedAt = m.CreatedAt,
            }
            ).ToListAsync();
        }

        public async Task<MovieEntity> UpdateMovieAsync(UpdateMovieRequest request)
        {
            var choisedMovie = await _db.Movies.FirstOrDefaultAsync(m => m.Id == request.Id);

            if (choisedMovie                                                                                                                                                                                                                                                                                                                                                           == null)
            {
                throw new ArgumentException("Movie Not Found");
            }

            choisedMovie.Title = request.Title;
            choisedMovie.Description = request.Description;
            choisedMovie.Director = request.Director;
            choisedMovie.Release = request.Release;

            _db.Movies.Update(choisedMovie);

            return choisedMovie;
        }

        public async Task DeleteMovieAsync(DeleteMovieRequest request)
        {
            var movie = await _db.Movies.FirstOrDefaultAsync(m => m.Id == request.Id);

            if (movie == null)
            {
                throw new ArgumentException("Movie Not Found");
            }

            movie.Status = DB.Entities.MovieStatus.Deleted;

            _db.Movies.Update(movie);
        }
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
