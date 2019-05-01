using System;
using System.Collections.Generic;

namespace MovieDatabase.API.ViewModel.Movie
{
    public class MovieListItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string PosterPath { get; set; }

        public string BackdropPath { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
