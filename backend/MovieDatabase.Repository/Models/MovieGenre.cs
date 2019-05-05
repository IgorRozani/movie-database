using System.Collections.Generic;

namespace MovieDatabase.Repository.Models
{

    public class MovieGenre
    {
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
