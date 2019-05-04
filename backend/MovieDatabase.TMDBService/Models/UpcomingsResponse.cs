using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieDatabase.TMDBService.Models
{
    public class UpcomingsResponse
    {
        public ICollection<UpcomingItem> Results { get; set; }

        public int Page { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public int TotalResults { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }

        public DatePeriod Dates { get; set; }
    }

    public class DatePeriod
    {
        public string Maximum { get; set; }
        public string Minimum { get; set; }
    }

    public class UpcomingItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty(PropertyName = "backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty(PropertyName = "genre_ids")]
        public ICollection<int> GenreIds { get; set; }

        public ICollection<GenreItem> Genres { get; set; }
    }
}
