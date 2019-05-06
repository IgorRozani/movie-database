using System;
using System.Collections.Generic;

namespace MovieDatabase.Repository.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string PosterPath { get; set; }

        public string BackdropPath { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
