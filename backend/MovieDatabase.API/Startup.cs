using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieDatabase.RestClient.Interfaces;
using MovieDatabase.TMDBService;
using MovieDatabase.TMDBService.Interfaces;
using MovieDatabase.TMDBService.Services;
using System;
using System.IO;
using System.Reflection;

namespace MovieDatabase.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();

            services.AddOptions();

            var tmdbConfig = Configuration.GetSection("TMDBConfig").Get<TMDBConfig>();
            services.AddSingleton(tmdbConfig);

            services.AddScoped<IRestClient, RestClient.Services.RestClient>();
            services.AddScoped<IConfigurationAPI, ConfigurationAPI>();
            services.AddScoped<IGenreAPI, GenreAPI>();
            services.AddScoped<IMovieAPI, MovieAPI>();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Movie Database API",
                    Version = "v1",
                    Description = "Check out the upcoming movies in the movie theather",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Name = "Igor G. O. Rozani",
                        Email = "igorrozani@gmail.com"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Database API v1");
            });
        }
    }
}
