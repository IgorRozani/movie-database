using MovieDatabase.API.TMDBService.Models;
using System.Threading.Tasks;

namespace MovieDatabase.TMDBService.Interface
{
    public interface IMovieAPI
    {
        Task<MovieDetailResponse> GetDetailsAsync(int id);

        Task<UpcomingsResponse> GetUpcomingsAsync(int page);
    }
}
