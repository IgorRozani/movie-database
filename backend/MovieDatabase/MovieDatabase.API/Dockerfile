FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["MovieDatabase.API/MovieDatabase.API.csproj", "MovieDatabase.API/"]
RUN dotnet restore "MovieDatabase.API/MovieDatabase.API.csproj"
COPY . .
WORKDIR "/src/MovieDatabase.API"
RUN dotnet build "MovieDatabase.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MovieDatabase.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MovieDatabase.API.dll"]