using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.API.ViewModel.Movie;
using MovieDatabase.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace MovieDatabase.API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : BaseAPIControllre
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMapper mapper, IMovieRepository movieRepository) : base(mapper)
        {
            _movieRepository = movieRepository;
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
        /// <response code="404">Movie not found</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<MovieDetails> GetDetails([FromRoute]int id)
        {
            if (id <= 0)
                return BadRequest("Invalid movie id");

            var movie = _movieRepository.Get(id);

            if (movie == null)
                return NotFound();

            return Ok(_mapper.Map<MovieDetails>(movie));
        }

        /// <summary>
        /// Get upcoming movies list
        /// </summary>
        /// <param name="movieName">Movie name</param>
        /// <param name="page">List page</param>
        /// <param name="quantityItems">Quantity itens per page</param>
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
        public ActionResult<List<MovieListItem>> Get([Optional]string movieName, [FromQuery]int page = 1, [FromQuery]int quantityItems = 20)
        {
            if (page <= 0 || quantityItems <= 0)
                return BadRequest("Invalid paramters.");

            var moviesQuery = _movieRepository.GetAll();
            if (!string.IsNullOrEmpty(movieName))
                moviesQuery = moviesQuery.Where(m => m.Title.Contains(movieName));

            var movies = moviesQuery.OrderBy(m => m.ReleaseDate).Skip((page - 1) * quantityItems).Take(quantityItems).ToList();

            return Ok(_mapper.Map<ICollection<MovieListItem>>(movies));
        }
    }
}