using MovieDatabase.API.RestClient.Interface;
using MovieDatabase.API.TMDBService.Models;
using MovieDatabase.TMDBService.Interface;
using System.Threading.Tasks;

namespace MovieDatabase.API.TMDBService.Services
{
    public class MovieAPI : BaseTMDBAPI, IMovieAPI
    {
        public MovieAPI(TMDBConfig tmdbConfig, IRestClient restClient) : base(tmdbConfig, restClient)
        {
        }

        public async Task<MovieDetailResponse> GetDetailsAsync(int id) =>
            await _restClient.GetJsonAsync<MovieDetailResponse>(_tmdbConfig.BaseUrl, $"{_tmdbConfig.MovieDetailPath}/{id}", GetBaseParameters());

        public async Task<UpcomingsResponse> GetUpcomingsAsync(int page)
        {
            var parameters = GetBaseParameters();
            parameters.Add("page", page.ToString());

            return await _restClient.GetJsonAsync<UpcomingsResponse>(_tmdbConfig.BaseUrl, _tmdbConfig.UpcomingPath, parameters);
        }

    }
}
