using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.API.ViewModel.Genre;
using MovieDatabase.TMDBService.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MovieDatabase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : BaseAPIControllre
    {
        private readonly IGenreAPI _genreAPI;

        public GenreController(IGenreAPI genreAPI, IMapper mapper) : base(mapper)
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
        /// <response code="200">Problem in getting genres</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ICollection<GenreListItem>>>GetGenres()
        {
            var genres = await _genreAPI.GetGenresAsync();

            if (genres == null || genres.Genres == null)
                return BadRequest();

            var genresViewModel = _mapper.Map<ICollection<GenreListItem>>(genres.Genres);

            return Ok(genresViewModel.OrderBy(g => g.Name));
        }
    }
}