using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieDatabase.API.RestClient.Interface
{
    public interface IRestClient
    {
        Task<T> GetJsonAsync<T>(string url, string path, Dictionary<string, string> parameters);
    }
}
