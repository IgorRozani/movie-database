using Microsoft.AspNetCore.Mvc;
using MovieDatabase.RestClient.Interfaces;
using MovieDatabase.TMDBService.Models;
using MovieDatabase.TMDBService.Interfaces;

namespace MovieDatabase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : BaseAPIController
    {
        private readonly IGenreAPI _genreAPI;

        public GenreController(IRestClient restClient, IGenreAPI genreAPI) : base(restClient)
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