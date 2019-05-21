using MovieDatabase.RestClient.Interfaces;
using MovieDatabase.TMDBService.Interfaces;
using MovieDatabase.TMDBService.Models;
using System.Threading.Tasks;

namespace MovieDatabase.TMDBService.Services
{
    public class MovieAPI : BaseTMDBAPI, IMovieAPI
    {
        private ImageConfiguration _imageConfiguration;

        public MovieAPI(TMDBConfig tmdbConfig, IRestClient restClient) : base(tmdbConfig, restClient)
        {
        }

        public async Task<MovieDetailResponse> GetDetailsAsync(int id) =>
            await _restClient.GetJsonAsync<MovieDetailResponse>(_tmdbConfig.BaseUrl, $"{_tmdbConfig.MovieDetailPath}/{id}", GetBaseParameters());

        public async Task<UpcomingsResponse> GetUpcomingsAsync(int page)
        {
            var parameters = GetBaseParameters();
            parameters.Add("page", page.ToString());
            parameters.Add("region", _tmdbConfig.Region);

            return await _restClient.GetJsonAsync<UpcomingsResponse>(_tmdbConfig.BaseUrl, _tmdbConfig.UpcomingPath, parameters);
        }

        private string GetImagePath(string path) =>
            _imageConfiguration.BaseUrl + _tmdbConfig.ImageSize + path;
    }
}
