using AutoMapper;
using MovieDatabase.API.ViewModel.Movie;
using MovieDatabase.TMDBService.Models;
using System;
using System.Linq;

namespace MovieDatabase.API.AutoMapper
{

    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDetailResponse, MovieDetails>()
                .ForMember(vm => vm.ReleaseDate, s => s.MapFrom(m => Convert.ToDateTime(m.ReleaseDate)))
                .ForMember(vm => vm.Genres, s => s.MapFrom(m => string.Join(", ", m.Genres.Select(g => g.Name))));

            CreateMap<UpcomingItem, MovieListItem>()
                .ForMember(vm => vm.ReleaseDate, s => s.MapFrom(m => Convert.ToDateTime(m.ReleaseDate)))
                .ForMember(vm => vm.Genres, s => s.MapFrom(m => string.Join(", ", m.Genres.Select(g => g.Name))));
        }
    }
}
