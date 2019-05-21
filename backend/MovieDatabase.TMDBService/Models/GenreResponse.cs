using System.Collections.Generic;

namespace MovieDatabase.TMDBService.Models
{
    public class GenreResponse
    {
        public List<GenreItem> Genres { get; set; }
    }

    public class GenreItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
