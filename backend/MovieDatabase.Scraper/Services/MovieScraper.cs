using AutoMapper;
using MovieDatabase.Repository.Interfaces;
using MovieDatabase.Repository.Models;
using MovieDatabase.Scraper.Interfaces;
using MovieDatabase.TMDBService.Interfaces;
using MovieDatabase.TMDBService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Scraper.Services
{
    public class MovieScraper : IMovieScraper
    {
        private readonly IMovieAPI _movieApi;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieScraper(IMovieAPI movieApi, IMovieRepository movieRepository, IMapper mapper)
        {
            _movieApi = movieApi;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public void Scrape()
        {
            var upcomingMoviesResponse = _movieApi.GetUpcomingsAsync(1);

            Task.WaitAll(upcomingMoviesResponse);

            var pagesResponse = new List<Task<UpcomingsResponse>>();
            for(var page = 2; page <= upcomingMoviesResponse.Result.TotalPages; page++)
            {
                pagesResponse.Add(_movieApi.GetUpcomingsAsync(page));
            }

            Task.WaitAll(pagesResponse.ToArray());

            var upcomingMoviesTMDB = upcomingMoviesResponse.Result.Results.ToList();
            pagesResponse.ForEach(r => upcomingMoviesTMDB.AddRange(r.Result.Results));

            var moviesInDatabase = _movieRepository.GetAll().ToList();

            var idsInDatabase = moviesInDatabase.Select(g => g.Id);

            foreach (var upcomingMovieTMDB in upcomingMoviesTMDB)
            {
                var movie = _mapper.Map<Movie>(upcomingMovieTMDB);
                if (!idsInDatabase.Contains(upcomingMovieTMDB.Id))
                    _movieRepository.Add(movie);
                else
                    _movieRepository.Update(movie);
            }

            var idsInTMDB = upcomingMoviesTMDB.Select(tg => tg.Id);
            foreach (var genreInDatabase in moviesInDatabase.Where(g => !idsInTMDB.Contains(g.Id)))
            {
                _movieRepository.Delete(genreInDatabase.Id);
            }

            _movieRepository.Save();
        }
    }
}
