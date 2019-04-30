using MovieDatabase.API.RestClient.Interface;
using MovieDatabase.API.TMDBService.Models;
using MovieDatabase.TMDBService.Interface;
using System.Threading.Tasks;

namespace MovieDatabase.API.TMDBService.Services
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
