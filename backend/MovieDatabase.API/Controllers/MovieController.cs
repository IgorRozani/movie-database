using Microsoft.AspNetCore.Mvc;
using MovieDatabase.API.TMDB.Movie;
using MovieDatabase.API.TMDB.Movie.Model;

namespace MovieDatabase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseAPIController
    {
        private readonly MovieAPI _movieAPI;

        public MovieController(Microsoft.Extensions.Options.IOptions<TMDB.TMDBConfig> tmdbConfig) : base(tmdbConfig)
        {
            _movieAPI = new MovieAPI(tmdbConfig.Value, _restClient);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<MovieDetailResponse> GetDetails(int id)
        {
            var movie = _movieAPI.GetDetailsAsync(id);

            return Ok(movie.Result);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<UpcomingsResponse> Get(int page = 1)
        {
            var upcomings = _movieAPI.GetUpcomingsAsync(page);

            return Ok(upcomings.Result);
        }
    }
}