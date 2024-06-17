//Setup
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();

//Content
string htmx = $"""
<html>
    <body>
        <script src="https://unpkg.com/htmx.org@1.9.12"></script>
        <!-- have a button POST a click via AJAX -->
        <button hx-post="/clicked" hx-swap="outerHTML">
        Click Me
        </button>
    </body>
</html>
""";
string html = $"""
<!doctype html>
<html lang="en-US">
  <head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>My test page</title>
  </head>
  <body>
    <img src="images/firefox-icon.png" alt="My test image" />
  </body>
</html>
""";

//Routes
app.MapGet("/", () => "Hello ゴジラ (Godzilla)!");
app.MapGet("/html", () =>  Results.Content(html, "text/html"));
app.MapGet("/htmx", () =>  Results.Content(htmx, "text/html"));

//Liftoff
app.Run();
