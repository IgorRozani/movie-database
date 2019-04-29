using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.API.TMDB;

namespace MovieDatabase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        [HttpGet]
        public ActionResult<GenreResponse> GetGenres()
        {
            var genres = new GenreAPI().GetGenresAsync();

            return Ok(genres.Result);

        }
    }
}