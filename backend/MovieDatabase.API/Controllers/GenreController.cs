using Microsoft.AspNetCore.Mvc;
using MovieDatabase.TMDBService.Interfaces;
using MovieDatabase.TMDBService.Models;

namespace MovieDatabase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : BaseAPIControllre
    {
        private readonly IGenreAPI _genreAPI;

        public GenreController(IGenreAPI genreAPI)
        {
            _genreAPI = genreAPI;
        }

        /// <summary>
        /// Get all movie genres
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/genre/
        /// </remarks>
        /// <response code="200">List of movie genres</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<GenreResponse> GetGenres()
        {
            var genres = _genreAPI.GetGenresAsync();

            return Ok(genres.Result);
        }
    }
}