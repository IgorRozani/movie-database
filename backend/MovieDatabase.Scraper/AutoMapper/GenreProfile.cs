using AutoMapper;
using MovieDatabase.Repository.Models;
using MovieDatabase.TMDBService.Models;

namespace MovieDatabase.Scraper.AutoMapper
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<GenreItem, Genre>();
        }
    }
}
