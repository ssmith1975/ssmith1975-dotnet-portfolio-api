FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src

COPY ["Portfolio.EntityModels.PostgreSQL/Portfolio.EntityModels.PostgreSQL.csproj", "Portfolio.EntityModels.PostgreSQL/"]
COPY ["Portfolio.DataContext.PostgreSQL/Portfolio.DataContext.PostgreSQL.csproj", "Portfolio.DataContext.PostgreSQL/"]
COPY ["Portfolio.WebApi/Portfolio.WebApi.csproj", "Portfolio.WebApi/"]
RUN dotnet restore "./Portfolio.WebApi/Portfolio.WebApi.csproj"
COPY . .

WORKDIR "/src/Portfolio.WebApi"
RUN dotnet build "Portfolio.WebApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Portfolio.WebApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Portfolio.WebApi.dll"]