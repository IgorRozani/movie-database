using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Repository.Models;

namespace MovieDatabase.Repository.Configurations
{
    public class UpcomingMovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Title).IsRequired();

            builder.Property(u => u.ReleaseDate).IsRequired();

            builder.HasMany(u => u.MovieGenres).WithOne(mg => mg.Movie).HasForeignKey(mg => mg.MovieId);
        }
    }
}
