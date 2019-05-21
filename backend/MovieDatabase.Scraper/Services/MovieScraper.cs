using AutoMapper;
using MovieDatabase.Repository.Interfaces;
using MovieDatabase.Repository.Models;
using MovieDatabase.Scraper.Interfaces;
using MovieDatabase.TMDBService;
using MovieDatabase.TMDBService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Scraper.Services
{
    public class MovieScraper : IMovieScraper
    {
        private readonly IMovieAPI _movieApi;
        private readonly IConfigurationAPI _configurationApi;
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly TMDBConfig _tmdbConfig;

        public MovieScraper(IMovieAPI movieApi, IConfigurationAPI configurationApi, TMDBConfig tmdbConfig, IMovieRepository movieRepository, IGenreRepository genreRepository, IMapper mapper)
        {
            _movieApi = movieApi;
            _configurationApi = configurationApi;
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
            _tmdbConfig = tmdbConfig;
        }

        public void Scrape()
        {
            var page = 1;
            var totalPages = 0;

            var moviesInDatabase = _movieRepository.GetAll().ToList();
            var idsInDatabase = moviesInDatabase.Select(g => g.Id);
            var genres = _genreRepository.GetAll().ToList();

            var configuration = _configurationApi.GetConfigurationAsync();

            Task.WaitAll(configuration);

            var tmdbMoviesId = new List<int>();

            do
            {
                var upcomingMoviesResponse = _movieApi.GetUpcomingsAsync(page);
                Task.WaitAll(upcomingMoviesResponse);

                totalPages = upcomingMoviesResponse.Result.TotalPages;

                foreach (var upcomingMovieTMDB in upcomingMoviesResponse.Result.Results)
                {
                    tmdbMoviesId.Add(upcomingMovieTMDB.Id);
                    var movie = _mapper.Map<Movie>(upcomingMovieTMDB);

                    if (!string.IsNullOrEmpty(upcomingMovieTMDB.BackdropPath))
                        movie.BackdropPath = GetImagePath(configuration.Result.Images.BaseUrl, upcomingMovieTMDB.BackdropPath);
                    if (!string.IsNullOrEmpty(upcomingMovieTMDB.PosterPath))
                        movie.PosterPath = GetImagePath(configuration.Result.Images.BaseUrl, upcomingMovieTMDB.PosterPath);

                    movie.MovieGenres = new List<MovieGenre>();
                    foreach (var genreId in upcomingMovieTMDB.GenreIds)
                    {
                        movie.MovieGenres.Add(new MovieGenre
                        {
                            Movie = movie,
                            MovieId = movie.Id,
                            Genre = genres.FirstOrDefault(g => g.Id == genreId),
                            GenreId = genreId
                        });
                    }

                    if (!idsInDatabase.Contains(upcomingMovieTMDB.Id))
                        _movieRepository.Add(movie);
                    else
                        _movieRepository.Update(movie);
                }

                page++;
            } while (page <= totalPages);

            foreach (var genreInDatabase in moviesInDatabase.Where(g => !tmdbMoviesId.Contains(g.Id)))
                _movieRepository.Delete(genreInDatabase.Id);

            _movieRepository.Save();
        }

        private string GetImagePath(string basePath, string path) =>
            basePath + _tmdbConfig.ImageSize + path;
    } 
}
