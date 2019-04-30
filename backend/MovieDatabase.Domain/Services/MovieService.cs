using AutoMapper;
using MovieDatabase.Domain.Interfaces;
using MovieDatabase.Domain.Models;
using MovieDatabase.TMDBService.Interfaces;

namespace MovieDatabase.Domain.Services
{
    public class MovieService : BaseService, IMovieService
    {
        private IMovieAPI _movieAPI;

        public MovieService(IConfigurationAPI configurationAPI, IGenreAPI genreAPI, IMovieAPI movieAPI) : base(configurationAPI, genreAPI)
        {
            _movieAPI = movieAPI;
        }

        public MovieDetail Get(int id)
        {
            var movie = Mapper.Map<MovieDetail>(_movieAPI.GetDetailsAsync(id).Result);

            movie.PosterPath = $"{_imageConfiguration.BaseUrl}/{_imageConfiguration.ImageSize}/{movie.PosterPath}";
        }
            
    }
}
