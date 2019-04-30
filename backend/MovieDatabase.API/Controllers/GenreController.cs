using Microsoft.AspNetCore.Mvc;
using MovieDatabase.API.TMDB;
using MovieDatabase.API.TMDB.Genre;
using MovieDatabase.API.TMDB.Genre.Model;

namespace MovieDatabase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : BaseAPIController
    {
        private readonly GenreAPI _genreAPI;

        public GenreController(Microsoft.Extensions.Options.IOptions<TMDBConfig> tmdbConfig) : base(tmdbConfig)
        {
            _genreAPI = new GenreAPI(tmdbConfig.Value, _restClient);
        }

        [HttpGet]
        public ActionResult<GenreResponse> GetGenres()
        {
            var genres = _genreAPI.GetGenresAsync();

            return Ok(genres.Result);
        }
    }
}