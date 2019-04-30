using Microsoft.AspNetCore.Mvc;
using MovieDatabase.API.RestClient.Interface;
using MovieDatabase.API.TMDBService.Models;
using MovieDatabase.TMDBService.Interface;

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