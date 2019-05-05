using Flurl;
using Flurl.Http;
using MovieDatabase.RestClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieDatabase.RestClient.Services
{
    public class RestClient : IRestClient
    {
        public Task<T> GetJsonAsync<T>(string url, string path, Dictionary<string, string> parameters)
        {
            var serviceUrl = new Url(url).AppendPathSegment(path);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    serviceUrl.SetQueryParam(parameter.Key, parameter.Value);
            }

            try
            {
                return serviceUrl.GetJsonAsync<T>();
            }
            catch(FlurlHttpException ex)
            {
                return Task.FromResult<T>(default);
            }
            catch (Exception ex)
            {
                return Task.FromResult<T>(default);
            }
        }
    }
}
