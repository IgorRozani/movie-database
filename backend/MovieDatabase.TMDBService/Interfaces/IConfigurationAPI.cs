using MovieDatabase.TMDBService.Models;
using System.Threading.Tasks;

namespace MovieDatabase.TMDBService.Interfaces
{
    public interface IConfigurationAPI
    {
        Task<ConfigurationResponse> GetConfigurationAsync();

        Task<string> GetImageBaseUrlAsync();
    }
}
