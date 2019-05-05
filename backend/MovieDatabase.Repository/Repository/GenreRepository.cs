using Microsoft.EntityFrameworkCore;
using MovieDatabase.Repository.Interfaces;
using MovieDatabase.Repository.Models;
using System.Linq;

namespace MovieDatabase.Repository.Repository
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(MovieDataContext context) : base(context)
        {
        }

        public Genre Add(Genre entity) =>
            _context.Genres.Add(entity).Entity;

        public void Update(Genre entity) =>
            _context.Entry(entity).State = EntityState.Modified;

        public void Delete(int id)
        {
            var genre = Get(id);
            _context.Genres.Remove(genre);
        }

        public IQueryable<Genre> GetAll() =>
            _context.Genres.AsQueryable();

        public Genre Get(int id) =>
            _context.Genres.Find(id);
    }
}
