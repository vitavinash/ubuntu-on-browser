# MonsterASP.NET deployment checklist
+
+Run this locally from the repo root:
+
+```bash
+dotnet restore
+dotnet publish -c Release -o publish
+```
+
+Then upload the contents of the `publish` folder to the MonsterASP app root.
+
+Do not upload source files (`Program.cs`, `.csproj`, `Dockerfile`, etc.). Upload the compiled output only.
+
+The following files are required in the published output:
+
+- `UbuntuOnBrowser.dll`
+- `UbuntuOnBrowser.runtimeconfig.json`
+- `UbuntuOnBrowser.deps.json`
+- `web.config`
+
+Important:
+
+- MonsterASP.NET is Windows/IIS. It cannot run the Linux Docker `ttyd` terminal from this repo.
+- The original Ubuntu browser terminal must be deployed to Render, Railway, or another Linux container service.
+- This app is a publishable ASP.NET Core app that can be hosted on MonsterASP; it is not the Ubuntu terminal itself.
