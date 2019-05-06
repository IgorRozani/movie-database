using Microsoft.EntityFrameworkCore;
using MovieDatabase.Repository.Interfaces;
using MovieDatabase.Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieDatabase.Repository.Repository
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        public MovieRepository(MovieDataContext context) : base(context)
        {
        }

        public Movie Add(Movie movie)
        {
            var movieEntity = _context.Movies.Add(movie).Entity;

            AddMovieGenres(movie.MovieGenres);

            return movieEntity;
        }

        public void Update(Movie movie) =>
            _context.Entry(movie).State = EntityState.Modified;

        public void Delete(int id)
        {
            var movie = Get(id);

            RemoveMovieGenres(movie.MovieGenres);

            _context.Movies.Remove(movie);
        }

        public Movie Get(int id) =>
            _context.Movies
                .Include(m => m.MovieGenres)
                .Include("MovieGenres.Genre").FirstOrDefault(m => m.Id == id);

        public IQueryable<Movie> GetAll() =>
            _context.Movies
                .Include(m => m.MovieGenres)
                .Include("MovieGenres.Genre").AsNoTracking().AsQueryable();

        private void AddMovieGenres(ICollection<MovieGenre> movieGenres)
        {
            foreach (var movieGenre in movieGenres)
                _context.MovieGenres.Add(movieGenre);
        }

        private void RemoveMovieGenres(ICollection<MovieGenre> movieGenres)
        {
            foreach (var movieGenre in movieGenres)
                _context.MovieGenres.Remove(movieGenre);
        }
    }
}
