using System.Collections.Generic;

namespace MovieDatabase.API.TMDB
{

    public class BaseTMDBAPI
    {
        protected TMDBConfig _tmdbConfig;
        protected RestClient.RestClient _restClient;

        public BaseTMDBAPI(TMDBConfig tmdbConfig, RestClient.RestClient restClient)
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
