using AutoMapper;
using MovieDatabase.Repository.Interfaces;
using MovieDatabase.Repository.Models;
using MovieDatabase.Scraper.Interfaces;
using MovieDatabase.TMDBService.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Scraper.Services
{
    public class GenreScraper : IGenreScraper
    {
        private readonly IGenreAPI _genreApi;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreScraper(IGenreAPI genreApi, IGenreRepository genreRepository, IMapper mapper)
        {
            _genreApi = genreApi;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
      
        public void Scrape()
        {
            var tmdbGenres = _genreApi.GetGenresAsync();

            Task.WaitAll(tmdbGenres);

            var genresInDatabase = _genreRepository.GetAll().ToList();

            var idsInDatabase = genresInDatabase.Select(g => g.Id);
            foreach (var tmdbGenre in tmdbGenres.Result.Genres)
            {
                var genre = _mapper.Map<Genre>(tmdbGenre);
                if (!idsInDatabase.Contains(tmdbGenre.Id))
                    _genreRepository.Add(genre);
                else
                    _genreRepository.Update(genre);
            }

            var idsInTMDB = tmdbGenres.Result.Genres.Select(tg => tg.Id);
            foreach (var genreInDatabase in genresInDatabase.Where(g => !idsInTMDB.Contains(g.Id)))
            {
                _genreRepository.Delete(genreInDatabase.Id);
            }

            _genreRepository.Save();
        }
    }
}
