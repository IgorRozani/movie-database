using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.API.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterPath { get; set; }

    }
}
