using MovieDatabase.TMDBService.Models;
using System.Threading.Tasks;

namespace MovieDatabase.TMDBService.Interfaces
{
    public interface IGenreAPI
    {
        Task<GenreResponse> GetGenresAsync();
    }
}
