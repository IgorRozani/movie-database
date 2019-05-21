using MovieDatabase.TMDBService.Models;
using System.Threading.Tasks;

namespace MovieDatabase.TMDBService.Interfaces
{
    public interface IMovieAPI
    {
        Task<MovieDetailResponse> GetDetailsAsync(int id);

        Task<UpcomingsResponse> GetUpcomingsAsync(int page);
    }
}
