var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/health", () => Results.Ok(new
{
    status = "ok",
    service = "ubuntu-on-browser",
    runtime = $".NET {Environment.Version}"
}));

app.MapFallback(async context =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync("""
        <!doctype html>
        <html lang="en">
        <head>
          <meta charset="utf-8">
          <meta name="viewport" content="width=device-width, initial-scale=1">
          <title>Ubuntu on Browser</title>
          <style>
            body { margin:0; background:#111; color:#eee; font:16px system-ui,sans-serif; }
            main { max-width:760px; margin:10vh auto; padding:2rem; }
            code { color:#9fef00; }
            .box { background:#1d1d1d; border:1px solid #444; border-radius:10px; padding:1.25rem; }
            a { color:#70b7ff; }
          </style>
        </head>
        <body>
          <main>
            <h1>Ubuntu on Browser</h1>
            <div class="box">
              <p>The ASP.NET Core application is running successfully.</p>
              <p><strong>Health check:</strong> <a href="/health">/health</a></p>
              <p>This Windows/IIS deployment cannot run the repository's Linux <code>ttyd</code> Ubuntu terminal.</p>
              <p>Deploy the original Dockerfile to Render, Railway, or another Linux container host for the interactive Ubuntu terminal.</p>
            </div>
          </main>
        </body>
        </html>
        """);
});

app.Run();
