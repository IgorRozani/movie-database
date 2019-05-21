using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieDatabase.Repository;
using MovieDatabase.Repository.Interfaces;
using MovieDatabase.Repository.Repository;
using MovieDatabase.RestClient.Interfaces;
using MovieDatabase.Scraper.Interfaces;
using MovieDatabase.Scraper.Services;
using MovieDatabase.TMDBService;
using MovieDatabase.TMDBService.Interfaces;
using MovieDatabase.TMDBService.Services;
using System;
using System.IO;

namespace MovieDatabase.Scraper
{
    class Program
    {
        private static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            ConfigureDependencies();

            Console.WriteLine("Scraping genres");
            var genreScraper = _serviceProvider.GetService<IGenreScraper>();
            genreScraper.Scrape();

            Console.WriteLine("Scraping movies");
            var movieScraper = _serviceProvider.GetService<IMovieScraper>();
            movieScraper.Scrape();


            Console.WriteLine("Scraper has finished");
        }

        private static void ConfigureDependencies()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            var tmdbConfig = configuration.GetSection("TMDBConfig").Get<TMDBConfig>();

            var connectionString = string.Empty;
#if DEBUG
            connectionString = configuration.GetConnectionString("DebugConnection");
#else
            connectionString = configuration.GetConnectionString("DefaultConnection");
#endif

            _serviceProvider = new ServiceCollection()
                .AddAutoMapper()
                .AddSingleton<IRestClient, RestClient.Services.RestClient>()
                .AddSingleton<IConfigurationAPI, ConfigurationAPI>()
                .AddSingleton<IGenreAPI, GenreAPI>()
                .AddSingleton<IMovieAPI, MovieAPI>()
                .AddSingleton<IConfigurationAPI, ConfigurationAPI>()
                .AddSingleton<IMovieRepository, MovieRepository>()
                .AddSingleton<IGenreRepository, GenreRepository>()
                .AddSingleton<IGenreScraper, GenreScraper>()
                .AddSingleton<IMovieScraper, MovieScraper>()
                .AddSingleton(tmdbConfig)
                .AddDbContext<MovieDataContext>(options => options.UseMySql(connectionString))
            .BuildServiceProvider();

            var context = _serviceProvider.GetService<MovieDataContext>();
            context.Database.Migrate();
        }
    }
}
