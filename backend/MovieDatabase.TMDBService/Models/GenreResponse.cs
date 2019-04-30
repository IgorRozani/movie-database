using System.Collections.Generic;

namespace MovieDatabase.TMDBService.Models
{
    public class GenreResponse
    {
        public List<Genre> Genres { get; set; }

        public class Genre
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
