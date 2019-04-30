using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieDatabase.API.RestClient
{
    public class RestClient
    {
        public async Task<T> GetJsonAsync<T>(string url, string path, Dictionary<string, string> parameters)
        {
            var restUrl = new Url(url).AppendPathSegment(path);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    restUrl.SetQueryParam(parameter.Key, parameter.Value);
            }

            return await restUrl.GetJsonAsync<T>();
        }
    }
}
