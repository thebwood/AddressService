#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AddressService.API/AddressService.API.csproj", "AddressService.API/"]
COPY ["AddressService.ClassLibrary/AddressService.ClassLibrary.csproj", "AddressService.ClassLibrary/"]
COPY ["AddressService.Domain/AddressService.Domain.csproj", "AddressService.Domain/"]
COPY ["AddressService.Infrastructure/AddressService.Infrastructure.csproj", "AddressService.Infrastructure/"]
RUN dotnet restore "./AddressService.API/./AddressService.API.csproj"
COPY . .
WORKDIR "/src/AddressService.API"
RUN dotnet build "./AddressService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AddressService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AddressService.API.dll"]