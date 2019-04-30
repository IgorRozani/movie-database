using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieDatabase.TMDBService.Models
{
    public class ConfigurationResponse
    {
        public ImageConfiguration Images { get; set; }
    }

    public class ImageConfiguration
    {
        [JsonProperty(PropertyName = "base_url")]
        public string BaseUrl { get; set; }

        [JsonProperty("backdrop_sizes")]
        public ICollection<string> BackdropSizes { get; set; }

        [JsonProperty(PropertyName = "poster_sizes")]
        public ICollection<string> PosterSizes { get; set; }
    }
}
