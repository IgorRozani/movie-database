FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app-scraper

# copy csproj and restore as distinct layers
COPY *.sln .
COPY MovieDatabase.API/. ./MovieDatabase.API/
COPY MovieDatabase.RestClient/. ./MovieDatabase.RestClient/
COPY MovieDatabase.Scraper/. ./MovieDatabase.Scraper/
COPY MovieDatabase.Repository/. ./MovieDatabase.Repository/
COPY MovieDatabase.TMDBService/. ./MovieDatabase.TMDBService/
RUN dotnet restore

# copy everything else and build app
WORKDIR /app-scraper/MovieDatabase.Scraper
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app-scraper
COPY --from=build /app-scraper/MovieDatabase.Scraper/out ./
ENTRYPOINT ["dotnet", "MovieDatabase.Scraper.dll"]  