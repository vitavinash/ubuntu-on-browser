# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY UbuntuOnBrowser.csproj ./
RUN dotnet restore UbuntuOnBrowser.csproj

COPY . ./
RUN dotnet publish UbuntuOnBrowser.csproj \
    --configuration Release \
    --output /app/publish \
    --no-restore \
    --property:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_EnableDiagnostics=0

COPY --from=build /app/publish ./

EXPOSE 8080

# Railway, Render, and similar platforms provide PORT at runtime.
ENTRYPOINT ["sh", "-c", "ASPNETCORE_URLS=http://0.0.0.0:${PORT:-8080} exec dotnet UbuntuOnBrowser.dll"]
