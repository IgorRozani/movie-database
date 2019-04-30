using System.Collections.Generic;

namespace MovieDatabase.Domain.Models
{
    public class MovieDetail
    {
        public string Title { get; set; }

        public string Overview { get; set; }

        public string ReleaseDate { get; set; }

        public string PosterPath { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
