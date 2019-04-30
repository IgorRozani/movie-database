using AutoMapper;
using MovieDatabase.Domain.Configurations.Profiles;

namespace MovieDatabase.Domain.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<GenreProfile>();
            });
        }
    }
}
