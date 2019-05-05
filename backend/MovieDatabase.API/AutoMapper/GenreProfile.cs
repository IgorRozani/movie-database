using AutoMapper;
using MovieDatabase.API.ViewModel.Genre;
using MovieDatabase.Repository.Models;

namespace MovieDatabase.API.AutoMapper
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreListItem>();
        }
    }
}
