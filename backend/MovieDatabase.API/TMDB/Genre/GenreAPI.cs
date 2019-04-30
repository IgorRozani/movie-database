using MovieDatabase.API.TMDB.Genre.Model;
using System.Threading.Tasks;

namespace MovieDatabase.API.TMDB.Genre
{
    public class GenreAPI : BaseTMDBAPI
    {
        public GenreAPI(TMDBConfig tmdbConfig, RestClient.RestClient restClient) : base(tmdbConfig, restClient)
        {
        }

        public async Task<GenreResponse> GetGenresAsync() =>
            await _restClient.GetJsonAsync<GenreResponse>(_tmdbConfig.BaseUrl, _tmdbConfig.GenresPath, GetBaseParameters());
    }
}
