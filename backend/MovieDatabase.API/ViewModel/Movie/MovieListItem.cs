using System;

namespace MovieDatabase.API.ViewModel.Movie
{
    public class MovieListItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string PosterPath { get; set; }

        public string BackdropPath { get; set; }

        public string Genres { get; set; }
    }
}
