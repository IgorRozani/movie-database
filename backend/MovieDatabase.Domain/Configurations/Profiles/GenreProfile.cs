using AutoMapper;
using MovieDatabase.Domain.Models;
using MovieDatabase.TMDBService.Models;

namespace MovieDatabase.Domain.Configurations.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<GenreItem, Genre>();
        }
    }
}
