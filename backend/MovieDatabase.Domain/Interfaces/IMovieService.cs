using MovieDatabase.Domain.Models;

namespace MovieDatabase.Domain.Interfaces
{
    public interface IMovieService
    {
        MovieDetail Get(int id);

    }
}
