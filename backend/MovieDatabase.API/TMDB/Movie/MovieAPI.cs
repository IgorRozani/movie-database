using MovieDatabase.API.TMDB.Movie.Model;
using System.Threading.Tasks;

namespace MovieDatabase.API.TMDB.Movie
{
    public class MovieAPI : BaseTMDBAPI
    {
        public MovieAPI(TMDBConfig tmdbConfig, RestClient.RestClient restClient) : base(tmdbConfig, restClient)
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
