using Microsoft.AspNetCore.Mvc;
using MovieDatabase.TMDBService.Interfaces;
using MovieDatabase.TMDBService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseAPIControllre
    {
        private readonly IMovieAPI _movieAPI;

        public MovieController(IMovieAPI movieAPI)
        {
            _movieAPI = movieAPI;
        }

        /// <summary>
        /// Get movie details
        /// </summary>
        /// <param name="id">Movie id</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/movie/123
        /// </remarks>
        /// <response code="200">Movie details</response>
        /// <response code="400">Invalid movie id</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<MovieDetailResponse> GetDetails([FromRoute]int id)
        {
            var movie = _movieAPI.GetDetailsAsync(id);

            if (movie == null)
                return BadRequest("Invalid movie");

            return Ok(movie.Result);
        }

        /// <summary>
        /// Get upcoming movies list
        /// </summary>
        /// <param name="page">List page</param>
        /// <param name="quantityItens">Quantity itens per page</param>
        /// <remarks>
        /// Sample request:
        ///     
        ///     GET /api/movie?page=2
        /// </remarks>
        /// <response code="200">Upcoming movies list</response>
        /// <response code="400">Invalid params</response>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<UpcomingItem>>> Get([FromQuery]int page = 1, [FromQuery]int quantityItens = 20)
        {
            if (quantityItens % 20 != 0)
                return BadRequest("Invalid amountItens");

            var totalItems = page * quantityItens;
            var amountAPIPages = totalItems / 20;
            var pagesFromApi = quantityItens / 20;

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