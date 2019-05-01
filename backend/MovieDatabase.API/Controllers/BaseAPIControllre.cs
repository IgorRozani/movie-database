using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MovieDatabase.API.Controllers
{
    [Produces("application/json")]
    public class BaseAPIControllre : ControllerBase
    {
        protected readonly IMapper _mapper;

        public BaseAPIControllre(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
