using MovieDatabase.RestClient.Interfaces;
using MovieDatabase.TMDBService.Models;
using MovieDatabase.TMDBService.Interfaces;
using System.Threading.Tasks;

namespace MovieDatabase.TMDBService.Services
{
    public class ConfigurationAPI : BaseTMDBAPI, IConfigurationAPI
    {
        public ConfigurationAPI(TMDBConfig tmdbConfig, IRestClient restClient) : base(tmdbConfig, restClient)
        {
        }

        public async Task<ConfigurationResponse> GetConfigurationAsync() =>
            await _restClient.GetJsonAsync<ConfigurationResponse>(_tmdbConfig.BaseUrl, _tmdbConfig.ConfigurationPath, GetBaseParameters(false));
    }
}
