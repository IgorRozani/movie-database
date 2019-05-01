using AutoMapper;
using MovieDatabase.API.ViewModel.Movie;
using MovieDatabase.TMDBService.Models;
using System;

namespace MovieDatabase.API.AutoMapper
{

    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDetailResponse, MovieDetails>()
                .ForMember(vm => vm.ReleaseDate, s => s.MapFrom(m => Convert.ToDateTime(m.ReleaseDate)));

            CreateMap<UpcomingItem, MovieListItem>()
                .ForMember(vm => vm.ReleaseDate, s => s.MapFrom(m => Convert.ToDateTime(m.ReleaseDate)));
        }
    }
}
