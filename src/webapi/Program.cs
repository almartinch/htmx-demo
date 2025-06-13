//Dependencies
using Microsoft.AspNetCore.Mvc;

//Setup
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(o => {
    o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute()); // So no token needed
}).AddRazorRuntimeCompilation();
var app = builder.Build();
// app.UseHttpsRedirection();
app.UseStaticFiles();

//Deliver HTML over the wire, not JSON
var contentType = "text/html; charset=utf-8";

//Routes
// Home is Razor's index now. No need for explicit / route after adding Razor Pages.
// If you want to use the PagesRepository.Home, uncomment the line below and comment the Razor Pages line @31.
// app.MapGet("/", () => Results.Content(PagesRepository.Home, "text/html")); 
//Level0
app.MapGet("/0", () =>  Results.Content(PagesRepository.Level0, contentType));

//Level1
app.MapGet("/1", () =>  Results.Content(PagesRepository.Level1, contentType));
app.MapPost("/click", ([FromForm] int count) => Results.Content(PagesRepository.BuildForm(count + 1, "/click"), contentType))
  .DisableAntiforgery(); // So no token needed

//Level2
app.MapGet("/2", () =>  Results.Redirect("/"));

app.MapRazorPages();

//Liftoff 🚀
app.Run();
