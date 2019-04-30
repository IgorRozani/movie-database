using Microsoft.AspNetCore.Mvc;
using MovieDatabase.RestClient.Interfaces;

namespace MovieDatabase.API.Controllers
{
    public class BaseAPIController : ControllerBase
    {
        protected readonly IRestClient _restClient;

        public BaseAPIController(IRestClient restClient)
        {
            _restClient = restClient;
        }
    }
}
