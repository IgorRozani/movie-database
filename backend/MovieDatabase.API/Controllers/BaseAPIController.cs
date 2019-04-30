using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieDatabase.API.TMDB;

namespace MovieDatabase.API.Controllers
{
    public class BaseAPIController : ControllerBase
    {
        protected readonly IOptions<TMDBConfig> _tmdbConfig;
         
        protected readonly RestClient.RestClient _restClient;

        public BaseAPIController(IOptions<TMDBConfig> tmdbConfig)
        {
            _tmdbConfig = tmdbConfig;
            _restClient = new RestClient.RestClient();
        }
    }
}
