﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Repository.Models;

namespace MovieDatabase.Repository.Configurations
{

    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey(mg => new { mg.GenreId, mg.MovieId });

            builder.Property(mg => mg.GenreId).IsRequired();
            builder.Property(mg => mg.MovieId).IsRequired();

            builder.ToTable("MovieGenre");
        }
    }
}
