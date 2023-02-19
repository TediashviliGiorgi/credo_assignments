using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using MovieDatabase.API.DB.Entities;
using MovieDatabase.API.Models.Requests.MovieRequests;
using MovieDatabase.API.Repsositories;

namespace MovieDatabase.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
    
        [HttpPost("/add")]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieRequest request)
        {
            var movie = new MovieEntity();
           
            await _movieRepository.AddMovieAsync(request);
            await _movieRepository.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("/get")]
        public async Task<IActionResult> GetMovie(int id)
        {
           
           var movie = await _movieRepository.GetMovieAsync(id);
            if (movie == null)
            {
                return NotFound("Movie not found");
            }
            
            return Ok(movie);
        }

        [HttpPost("/search")]
        public async Task<IActionResult> SearchMovie(SearchMovieRequest request)
        {
            var movie = await _movieRepository.SearchMovieAsync(request);
            if (request.PageSize > 100)
            {
                return BadRequest("Page size must be a under 100");
            }
            return Ok(movie);
        }

        [HttpPost("/update")]
        public async Task<IActionResult> UpdateMovie(UpdateMovieRequest request)
        {
            var updatedMovie = await _movieRepository.UpdateMovieAsync(request);
            await _movieRepository.SaveChangesAsync();

            return Ok(updatedMovie);
        }

        [HttpPost("/delete")]
        public async Task<IActionResult> DeleteMovie(DeleteMovieRequest request)
        {
            await _movieRepository.DeleteMovieAsync(request);
            await _movieRepository.SaveChangesAsync();

            return Ok();

        }
    }
}
