# Ubuntu on Browser

This repository contains a deployable ASP.NET Core 8 application. It runs on Linux containers and supports platforms such as Railway, Render, Azure Container Apps, and any Docker-compatible host.

## Run locally with .NET 8

```bash
dotnet run
```

The application listens on the URL configured by ASP.NET Core. Open `/` in a browser and use `/health` for a health check.

## Run with Docker

```bash
docker build -t ubuntu-on-browser .
docker run --rm -p 8080:8080 -e PORT=8080 ubuntu-on-browser
```

Open http://localhost:8080.

The Docker image uses a multi-stage .NET 8 build: the SDK is used only during compilation and the smaller ASP.NET runtime image is used in production. The container reads the hosting platform's `PORT` environment variable and defaults to `8080`.

## Deployment

Set the service's start command to the Dockerfile default (no custom command is required). Configure the platform health check path as `/health` if health checks are supported.

> The previous Ubuntu/ttyd image provided an interactive shell. The .NET deployment is an ASP.NET Core web application and does not include ttyd or a shell terminal. Keep the original Linux terminal Dockerfile in a separate service if that capability is required.
