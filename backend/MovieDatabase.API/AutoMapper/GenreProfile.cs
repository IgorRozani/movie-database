using AutoMapper;
using MovieDatabase.API.ViewModel.Genre;
using MovieDatabase.TMDBService.Models;

namespace MovieDatabase.API.AutoMapper
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<GenreItem, GenreListItem>();
        }
    }
}
