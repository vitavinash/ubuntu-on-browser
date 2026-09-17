# Ubuntu on Browser

This repository contains a deployable ASP.NET Core 8 application with two hosting options:

- **MonsterASP.NET/IIS:** publish the application as a Windows x64 ASP.NET Core application.
- **Docker/Linux providers:** build and run the included multi-stage Dockerfile.

## MonsterASP.NET deployment

Publish the application first:

```bash
dotnet publish UbuntuOnBrowser.csproj -c Release -r win-x64 --self-contained false -o ./publish
```

Upload all files inside `publish/` to the MonsterASP.NET IIS application root. See [MONSTERASP-DEPLOY.md](MONSTERASP-DEPLOY.md) for the complete IIS deployment instructions.

## Run locally with .NET 8

```bash
dotnet run
```

Open the displayed URL in a browser and use `/health` for a health check.

## Run with Docker

```bash
docker build -t ubuntu-on-browser .
docker run --rm -p 8080:8080 -e PORT=8080 ubuntu-on-browser
```

Open http://localhost:8080.

The Docker image uses a multi-stage .NET 8 build and reads the hosting platform's `PORT` environment variable, defaulting to `8080`.

> The ASP.NET Core deployment is a web application and does not include ttyd or a Linux shell terminal. Keep the original Ubuntu/ttyd container on a Linux container host when that capability is required.
