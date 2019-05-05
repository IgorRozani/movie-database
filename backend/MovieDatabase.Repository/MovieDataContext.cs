using Microsoft.EntityFrameworkCore;
using MovieDatabase.Repository.Configurations;
using MovieDatabase.Repository.Models;

namespace MovieDatabase.Repository
{
    public class MovieDataContext : DbContext
    {
        public MovieDataContext(DbContextOptions<MovieDataContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UpcomingMovieConfiguration());
            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
        }
    }
}
