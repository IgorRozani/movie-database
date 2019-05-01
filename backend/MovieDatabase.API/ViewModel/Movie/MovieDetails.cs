using System;
using System.Collections.Generic;

namespace MovieDatabase.API.ViewModel.Movie
{
    public class MovieDetails
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string PosterPath { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
