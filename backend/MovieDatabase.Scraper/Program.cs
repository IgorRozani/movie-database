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

            _serviceProvider = new ServiceCollection()
                .AddAutoMapper()
                .AddScoped<IRestClient, RestClient.Services.RestClient>()
                .AddScoped<IConfigurationAPI, ConfigurationAPI>()
                .AddScoped<IGenreAPI, GenreAPI>()
                .AddScoped<IMovieAPI, MovieAPI>()
                .AddScoped<IConfigurationAPI, ConfigurationAPI>()
                .AddScoped<IMovieRepository, MovieRepository>()
                .AddScoped<IGenreRepository, GenreRepository>()
                .AddScoped<IGenreScraper, GenreScraper>()
                .AddScoped<IMovieScraper, MovieScraper>()
                .AddSingleton(tmdbConfig)
                .AddDbContext<MovieDataContext>(options => options.UseMySql(configuration.GetConnectionString("DefaultConnection")))
            .BuildServiceProvider();
        }
    }
}
