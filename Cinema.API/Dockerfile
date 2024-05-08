#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Cinema.API/Cinema.API.csproj", "Cinema.API/"]
COPY ["Cinema.BLL/Cinema.BLL.csproj", "Cinema.BLL/"]
COPY ["Cinema.DAL/Cinema.DAL.csproj", "Cinema.DAL/"]
COPY ["Cinema.Data/Cinema.Data.csproj", "Cinema.Data/"]
RUN dotnet restore "./Cinema.API/Cinema.API.csproj"
COPY . .
WORKDIR "/src/Cinema.API"
RUN dotnet build "./Cinema.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Cinema.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cinema.API.dll"]