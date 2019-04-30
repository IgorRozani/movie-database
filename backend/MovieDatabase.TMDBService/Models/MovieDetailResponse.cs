using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieDatabase.TMDBService.Models
{
    public class MovieDetailResponse
    {
        public string Title { get; set; }

        public string Overview { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string PosterPath { get; set; }

        public ICollection<GenreResponse.Genre> Genres { get; set; }
    }
}
