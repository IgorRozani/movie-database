using MovieDatabase.API.TMDBService.Models;
using System.Threading.Tasks;

namespace MovieDatabase.TMDBService.Interface
{
    public interface IConfigurationAPI
    {
        Task<ConfigurationResponse> GetConfigurationAsync();
    }
}
