using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieDatabase.RestClient.Interfaces;
using MovieDatabase.TMDBService;
using MovieDatabase.TMDBService.Services;
using MovieDatabase.TMDBService.Interfaces;

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

            services.AddOptions();

            var tmdbConfig = Configuration.GetSection("TMDBConfig").Get<TMDBConfig>();
            services.AddSingleton(tmdbConfig);

            services.AddScoped<IRestClient, RestClient.Services.RestClient>();
            services.AddScoped<IConfigurationAPI, ConfigurationAPI>();
            services.AddScoped<IGenreAPI, GenreAPI>();
            services.AddScoped<IMovieAPI, MovieAPI>();
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
        }
    }
}
