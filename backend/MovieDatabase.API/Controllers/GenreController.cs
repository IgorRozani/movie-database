using Microsoft.AspNetCore.Mvc;
using MovieDatabase.TMDBService.Interfaces;
using MovieDatabase.TMDBService.Models;

namespace MovieDatabase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreAPI _genreAPI;

        public GenreController(IGenreAPI genreAPI)
        {
            _genreAPI = genreAPI;
        }

        [HttpGet]
        public ActionResult<GenreResponse> GetGenres()
        {
            var genres = _genreAPI.GetGenresAsync();

            return Ok(genres.Result);
        }
    }
}