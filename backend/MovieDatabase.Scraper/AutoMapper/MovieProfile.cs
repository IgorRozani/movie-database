using AutoMapper;
using MovieDatabase.Repository.Models;
using MovieDatabase.TMDBService.Models;
using System;

namespace MovieDatabase.Scraper.AutoMapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<UpcomingItem, Movie>()
                .ForMember(s => s.ReleaseDate, d => d.MapFrom(vm => Convert.ToDateTime(vm.ReleaseDate)));
        }
    }
}
