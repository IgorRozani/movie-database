using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.TMDBService.Interface
{
  public interface IConfigurationAPI
    {
        async Task<ConfigurationResponse> GetConfigurationAsync();
    }
}
