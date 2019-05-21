FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY MovieDatabase.API/. ./MovieDatabase.API/
COPY MovieDatabase.RestClient/. ./MovieDatabase.RestClient/
COPY MovieDatabase.Scraper/. ./MovieDatabase.Scraper/
COPY MovieDatabase.Repository/. ./MovieDatabase.Repository/
COPY MovieDatabase.TMDBService/. ./MovieDatabase.TMDBService/
RUN dotnet restore

# copy everything else and build app
WORKDIR /app/MovieDatabase.API
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/MovieDatabase.API/out ./
ENTRYPOINT ["dotnet", "MovieDatabase.API.dll"]