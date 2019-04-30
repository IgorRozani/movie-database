using MovieDatabase.API.RestClient.Interface;
using MovieDatabase.API.TMDBService.Models;
using MovieDatabase.TMDBService.Interface;
using System.Threading.Tasks;

namespace MovieDatabase.API.TMDBService.Services
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
