# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Generita.Api/Generita.Api.csproj", "src/Generita.Api/"]
COPY ["src/Generita.Infrustructure/Generita.Infrustructure.csproj", "src/Generita.Infrustructure/"]
COPY ["src/Generita.Application/Generita.Application.csproj", "src/Generita.Application/"]
COPY ["src/Generita.Domain/Generita.Domain.csproj", "src/Generita.Domain/"]
RUN dotnet restore "./src/Generita.Api/Generita.Api.csproj"
COPY . .
WORKDIR "/src/src/Generita.Api"
RUN dotnet build "./Generita.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Generita.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
USER root
WORKDIR /app
COPY --from=publish --chown=app:app /app/publish .
RUN mkdir -p /app/wwwroot/files /app/wwwroot/images /app/wwwroot/Musics \
    && chown -R app:app /app/wwwroot
USER app
ENTRYPOINT ["dotnet", "Generita.Api.dll"]
