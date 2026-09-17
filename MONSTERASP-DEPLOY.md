# MonsterASP.NET deployment

The repository supports both Docker hosting and normal ASP.NET Core hosting on MonsterASP.NET/IIS.

## Publish for MonsterASP.NET

Install the .NET 8 SDK, then run this from the repository root:

```bash
dotnet publish UbuntuOnBrowser.csproj -c Release -r win-x64 --self-contained false -o ./publish
```

Upload **all files inside `publish/`** to the MonsterASP.NET IIS application root. Do not upload only the source `.cs` files or the `.csproj` file. The published directory must include:

- `UbuntuOnBrowser.dll`
- `UbuntuOnBrowser.deps.json`
- `UbuntuOnBrowser.runtimeconfig.json`
- `web.config`
- all other files produced by `dotnet publish`

The included `web.config` starts the ASP.NET Core application through IIS's ASP.NET Core Module. The application listens on the port assigned by IIS and does not require a `PORT` environment variable on MonsterASP.NET.

## Visual Studio

1. Open `UbuntuOnBrowser.csproj` in Visual Studio.
2. Select **Publish**.
3. Choose **Folder** as the target.
4. Select **Release**, `win-x64`, and **Framework-dependent**.
5. Publish and upload the contents of the generated folder to MonsterASP.NET.

The repository also includes `Properties/PublishProfiles/MonsterASP.pubxml` for file-system publishing.

## Verify the deployment

Open:

```text
https://your-domain.example/health
```

A successful deployment returns JSON showing `status: ok` and `.NET 8`.

## Important limitation

MonsterASP.NET/IIS can host the ASP.NET Core web application, but it cannot run the original Linux `ttyd` Ubuntu terminal from the Dockerfile. Use Railway, Render, or another Linux container provider for the interactive Ubuntu terminal.
