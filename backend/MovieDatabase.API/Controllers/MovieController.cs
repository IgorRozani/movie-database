using Microsoft.AspNetCore.Mvc;
using MovieDatabase.RestClient.Interfaces;
using MovieDatabase.TMDBService.Models;
using MovieDatabase.TMDBService.Interfaces;

namespace MovieDatabase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseAPIController
    {
        private readonly IMovieAPI _movieAPI;

        public MovieController(IRestClient restClient, IMovieAPI movieAPI) : base(restClient)
        {
            _movieAPI = movieAPI;
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