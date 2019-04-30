using Microsoft.AspNetCore.Mvc;
using MovieDatabase.RestClient.Interfaces;
using MovieDatabase.TMDBService.Models;
using MovieDatabase.TMDBService.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

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
        public async Task<ActionResult> Get(int page = 1, int amountItens = 20)
        {
            if (amountItens % 20 != 0)
                return BadRequest("Invalid amountItens");

            var totalItems = page * amountItens;
            var amountAPIPages = totalItems / 20;
            var pagesFromApi = amountItens / 20;

            var initialPage = amountAPIPages - (pagesFromApi - 1);

            var upcomings = new List<UpcomingItem>();
            for (var i = initialPage; i <= amountAPIPages; i++)
            {
                var upcoming = await _movieAPI.GetUpcomingsAsync(i);
                if (!upcoming.Results.Any())
                    break;
                upcomings.AddRange(upcoming.Results);
            }

            return Ok(upcomings);
        }
    }
}