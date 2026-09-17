var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new
{
    status = "ok",
    service = "ubuntu-on-browser",
    runtime = ".NET 8"
}));

app.MapGet("/", () => Results.Content("""
<!doctype html>
<html lang="en">
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>Ubuntu on Browser</title>
  <style>
    body { font-family: Arial, sans-serif; background:#0f172a; color:#f8fafc; margin:0; }
    .wrap { max-width:760px; margin:80px auto; background:#111827; border:1px solid #334155; border-radius:12px; padding:24px; }
    h1 { margin-top:0; }
    code { color:#86efac; }
    .small { color:#cbd5e1; }
  </style>
</head>
<body>
  <div class="wrap">
    <h1>Ubuntu on Browser</h1>
    <p>The ASP.NET Core app is running correctly.</p>
    <p><a href="/health">Health check</a></p>
    <p class="small">This site is a Windows/IIS-compatible wrapper. The original interactive Ubuntu terminal requires a Linux container host such as Render or Railway.</p>
  </div>
</body>
</html>
""", "text/html"));

app.Run();
