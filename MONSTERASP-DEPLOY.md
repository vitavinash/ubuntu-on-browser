# MonsterASP.NET deployment

## If the site shows HTTP 403.14

The 403.14 page means IIS is serving the folder as a static directory and did not find a default document. This branch now includes `index.html`, so uploading the repository root will display a page instead of the directory-listing error.

## Recommended ASP.NET Core deployment

For the ASP.NET Core application, do not upload the GitHub source directory directly. Publish it first:

```bash
dotnet publish -c Release -o publish
```

Upload **all files inside `publish/`** to the IIS application root. The upload must include `web.config`, `UbuntuOnBrowser.dll`, `UbuntuOnBrowser.deps.json`, and `UbuntuOnBrowser.runtimeconfig.json`.

If you upload only the source repository, IIS will not compile `Program.cs` or run the `.csproj`; it will serve files statically. `index.html` is included only as a fallback for that situation.

The `/health` endpoint is available after a successful ASP.NET Core publish. If `/health` returns 404 but `/` displays the static page, the published ASP.NET Core application has not been deployed.

## Terminal limitation

MonsterASP/IIS cannot run the Linux `ttyd` terminal from the Dockerfile. Deploy the original Dockerfile to Render, Railway, or another Linux container provider for the actual browser Ubuntu terminal.
