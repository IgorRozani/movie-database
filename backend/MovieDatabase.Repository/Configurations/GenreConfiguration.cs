using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Repository.Models;

namespace MovieDatabase.Repository.Configurations
{

    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name).IsRequired();

            builder.HasMany(g => g.MovieGenres).WithOne(mg => mg.Genre).HasForeignKey(mg => mg.GenreId);

            builder.ToTable("Genre");
        }
    }
}
