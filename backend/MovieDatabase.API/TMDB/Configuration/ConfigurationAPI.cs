using MovieDatabase.API.TMDB.Configuration.Model;
using System.Threading.Tasks;

namespace MovieDatabase.API.TMDB.Configuration
{
    public class ConfigurationAPI : BaseTMDBAPI
    {
        public ConfigurationAPI(TMDBConfig tmdbConfig, RestClient.RestClient restClient) : base(tmdbConfig, restClient)
        {
        }

        public async Task<ConfigurationResponse> GetConfigurationAsync() =>
            await _restClient.GetJsonAsync<ConfigurationResponse>(_tmdbConfig.BaseUrl, _tmdbConfig.ConfigurationPath, GetBaseParameters(false));
    }
}
