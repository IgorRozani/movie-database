using Microsoft.EntityFrameworkCore;
using MovieDatabase.Repository.Interfaces;
using MovieDatabase.Repository.Models;
using System.Linq;

namespace MovieDatabase.Repository.Repository
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        public MovieRepository(MovieDataContext context) : base(context)
        {
        }

        public Movie Add(Movie movie) =>
            _context.Movies.Add(movie).Entity;

        public void Update(Movie movie) =>
            _context.Entry(movie).State = EntityState.Modified;

        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            _context.Movies.Remove(movie);
        }

        public Movie Get(int id) =>
            _context.Movies
                .Include(m => m.MovieGenres)
                .Include("MovieGenres.Genre").FirstOrDefault(m => m.Id == id);

        public IQueryable<Movie> GetAll() =>
            _context.Movies
                .Include(m => m.MovieGenres)
                .Include("MovieGenres.Genre").AsQueryable();
    }
}
