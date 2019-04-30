using AutoMapper;
using MovieDatabase.Domain.Interfaces;
using MovieDatabase.Domain.Models;
using MovieDatabase.TMDBService.Interfaces;
using System.Collections.Generic;

namespace MovieDatabase.Domain.Services
{
    public class GenreService : BaseService, IGenreService
    {
        public GenreService(IConfigurationAPI configurationAPI, IGenreAPI genreAPI) : base(configurationAPI, genreAPI)
        {
        }

        public ICollection<Genre> GetAll()
        {
            return Mapper.Map<ICollection<Genre>>(_genres);
        }
    }
}
