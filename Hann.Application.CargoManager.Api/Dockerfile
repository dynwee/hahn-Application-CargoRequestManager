#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Hann.Application.CargoManager.Api/Hann.Application.CargoManager.Api.csproj", "Hann.Application.CargoManager.Api/"]
COPY ["Hann.Application.CargoManager.Infrastructure/Hann.Application.CargoManager.Infrastructure.csproj", "Hann.Application.CargoManager.Infrastructure/"]
COPY ["Hann.Application.CargoManager.Application/Hann.Application.CargoManager.Application.csproj", "Hann.Application.CargoManager.Application/"]
COPY ["Hann.Application.CargoManager.Domain/Hann.Application.CargoManager.Domain.csproj", "Hann.Application.CargoManager.Domain/"]
COPY ["Hann.Application.CargoManager.Persistence/Hann.Application.CargoManager.Persistence.csproj", "Hann.Application.CargoManager.Persistence/"]
RUN dotnet restore "Hann.Application.CargoManager.Api/Hann.Application.CargoManager.Api.csproj"
COPY . .
WORKDIR "/src/Hann.Application.CargoManager.Api"
RUN dotnet build "Hann.Application.CargoManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hann.Application.CargoManager.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hann.Application.CargoManager.Api.dll"]
