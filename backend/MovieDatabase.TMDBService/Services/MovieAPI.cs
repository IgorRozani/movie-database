using MovieDatabase.RestClient.Interfaces;
using MovieDatabase.TMDBService.Interfaces;
using MovieDatabase.TMDBService.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.TMDBService.Services
{
    public class MovieAPI : BaseTMDBAPI, IMovieAPI
    {
        private readonly IGenreAPI _genreAPI;
        private readonly IConfigurationAPI _configurationAPI;
        private ImageConfiguration _imageConfiguration;

        public MovieAPI(TMDBConfig tmdbConfig, IRestClient restClient, IConfigurationAPI configurationAPI, IGenreAPI genreAPI) : base(tmdbConfig, restClient)
        {
            _configurationAPI = configurationAPI;
            _genreAPI = genreAPI;
            GetImageConfiguration();
        }

        public async Task<MovieDetailResponse> GetDetailsAsync(int id)
        {
            var movieDetails = await _restClient.GetJsonAsync<MovieDetailResponse>(_tmdbConfig.BaseUrl, $"{_tmdbConfig.MovieDetailPath}/{id}", GetBaseParameters());

            movieDetails.PosterPath = GetImagePath(movieDetails.PosterPath);

            return movieDetails;
        }

        public async Task<UpcomingsResponse> GetUpcomingsAsync(int page)
        {
            var parameters = GetBaseParameters();
            parameters.Add("page", page.ToString());

            var upcomings = await _restClient.GetJsonAsync<UpcomingsResponse>(_tmdbConfig.BaseUrl, _tmdbConfig.UpcomingPath, parameters);

            var genres = await _genreAPI.GetGenresAsync();

            if (upcomings == null)
                return null;

            foreach (var upcoming in upcomings.Results)
            {
                upcoming.BackdropPath = GetImagePath(upcoming.BackdropPath);
                upcoming.PosterPath = GetImagePath(upcoming.PosterPath);

                upcoming.Genres = genres.Genres.Where(g => upcoming.GenreIds.Any(i => g.Id == i)).ToList();
            }

            return upcomings;
        }

        private string GetImagePath(string path) =>
            _imageConfiguration.BaseUrl + _tmdbConfig.ImageSize + path;

        private async Task GetImageConfiguration()
        {
            var configuration = await _configurationAPI.GetConfigurationAsync();
            _imageConfiguration = configuration.Images;
        }
    }
}
