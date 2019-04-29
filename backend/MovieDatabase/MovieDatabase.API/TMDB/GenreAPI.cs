using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.API.TMDB
{
    public class GenreAPI
    {
        public async Task<GenreResponse> GetGenresAsync()
        {
            return await "https://api.themoviedb.org/3/"
                .AppendPathSegment("genre/movie/list")
                .SetQueryParams(new { api_key = "1f54bd990f1cdfb230adb312546d765d", language = "en-US" })
                .GetJsonAsync<GenreResponse>();
        }
    }

    public class GenreResponse
    {
        public List<Genre> Genres { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
