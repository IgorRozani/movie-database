using System.Collections.Generic;

namespace MovieDatabase.Repository.Models
{

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
