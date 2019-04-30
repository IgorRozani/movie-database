using MovieDatabase.RestClient.Interfaces;
using MovieDatabase.TMDBService.Models;
using MovieDatabase.TMDBService.Interfaces;
using System.Threading.Tasks;

namespace MovieDatabase.TMDBService.Services
{
    public class GenreAPI : BaseTMDBAPI, IGenreAPI
    {
        public GenreAPI(TMDBConfig tmdbConfig, IRestClient restClient) : base(tmdbConfig, restClient)
        {
        }

        public async Task<GenreResponse> GetGenresAsync() =>
            await _restClient.GetJsonAsync<GenreResponse>(_tmdbConfig.BaseUrl, _tmdbConfig.GenresPath, GetBaseParameters());
    }
}
