using MovieDatabase.RestClient.Interfaces;
using System.Collections.Generic;

namespace MovieDatabase.TMDBService
{

    public class BaseTMDBAPI
    {
        protected TMDBConfig _tmdbConfig;
        protected IRestClient _restClient;

        public BaseTMDBAPI(TMDBConfig tmdbConfig, IRestClient restClient)
        {
            _tmdbConfig = tmdbConfig;
            _restClient = restClient;
        }

        protected Dictionary<string, string> GetBaseParameters(bool includeLanguage = true)
        {
            var parameters = new Dictionary<string, string>
            {
                { "api_key",_tmdbConfig.ApiKey },
                
            };

            if (includeLanguage)
                parameters.Add("language", _tmdbConfig.Language);

            return parameters;
        }
    }
}
