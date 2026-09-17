# ASP.NET Core deployment for MonsterASP.NET

This branch contains a real ASP.NET Core application that can be published to an IIS/Windows host such as MonsterASP.NET.

## Publish locally

Install the .NET 8 SDK, then run:

```bash
dotnet restore
dotnet publish -c Release -o publish
```

Upload the **contents** of the generated `publish` directory to the MonsterASP site root. Do not upload only the source files and do not upload the `publish` directory as an extra nested folder.

The upload must include:

- `UbuntuOnBrowser.dll`
- `UbuntuOnBrowser.deps.json`
- `UbuntuOnBrowser.runtimeconfig.json`
- `web.config`

Ensure the MonsterASP application is configured for a supported ASP.NET Core/.NET version. Browse to `/health` to verify the deployment.

## Important limitation

This ASP.NET Core version is an IIS-compatible status/site page. It does **not** run the Linux Ubuntu terminal or `ttyd`; those require a Linux container host. Use the repository Dockerfile on Render or Railway for the actual interactive Ubuntu terminal.
