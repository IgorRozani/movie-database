using MovieDatabase.TMDBService.Interfaces;
using MovieDatabase.TMDBService.Models;
using System.Collections.Generic;

namespace MovieDatabase.Domain.Services
{
    public class BaseService
    {
        protected readonly ImageConfiguration _imageConfiguration;
        protected readonly ICollection<GenreItem> _genres;

        public BaseService(IConfigurationAPI configurationAPI, IGenreAPI genreAPI)
        {
            _imageConfiguration = configurationAPI.GetConfigurationAsync().Result.Images;
            _genres = genreAPI.GetGenresAsync().Result.Genres;
        }
    }
}
