using Microsoft.AspNetCore.Mvc;
using MovieDatabase.API.RestClient.Interface;

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
