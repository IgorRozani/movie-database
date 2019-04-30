using AutoMapper;
using MovieDatabase.Domain.Models;
using MovieDatabase.TMDBService.Models;

namespace MovieDatabase.Domain.Configurations.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDetailResponse, MovieDetail>();
        }
    }
}
