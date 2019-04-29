using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieDatabase.API.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("{id:int}")]
        [HttpGet]
        public IActionResult GetMovie(int id)
        {
            return null;
        }

            
    }
}