using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.API.ViewModel.Genre;
using MovieDatabase.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MovieDatabase.API.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : BaseAPIControllre
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository, IMapper mapper) : base(mapper)
        {
            _genreRepository = genreRepository;
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
        [Route("")]
        public ActionResult<ICollection<GenreListItem>> GetGenres()
        {
            var genres = _genreRepository.GetAll().ToList();

            var genresViewModel = _mapper.Map<ICollection<GenreListItem>>(genres);

            if (genresViewModel != null)
                return Ok(genresViewModel);

            return Ok(genresViewModel.OrderBy(g => g.Name));
        }
    }
}