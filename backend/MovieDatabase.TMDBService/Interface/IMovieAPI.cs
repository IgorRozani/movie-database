using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.TMDBService.Interface
{
    public interface IMovieAPI
    {
        async Task<MovieDetailResponse> GetDetailsAsync(int id);

        async Task<UpcomingsResponse> GetUpcomingsAsync(int page);
    }
}
