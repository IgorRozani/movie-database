using AutoMapper;
using MovieDatabase.API.ViewModel.Movie;
using MovieDatabase.Repository.Models;
using System.Linq;

namespace MovieDatabase.API.AutoMapper
{

    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieListItem>()
                .ForMember(vm => vm.Genres, s => s.MapFrom(m => string.Join(", ", m.MovieGenres.Select(g => g.Genre.Name))));

            CreateMap<Movie, MovieDetails>()
                .ForMember(vm => vm.Genres, s => s.MapFrom(m => string.Join(", ", m.MovieGenres.Select(g => g.Genre.Name))));
        }
    }
}
