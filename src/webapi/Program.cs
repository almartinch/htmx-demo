//Dependencies
using Microsoft.AspNetCore.Mvc;

//Setup
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();
// app.UseHttpsRedirection(); 
app.UseStaticFiles();

//Routes
app.MapGet("/", () => Results.Content(PagesRepository.Home, "text/html"));
app.MapGet("/0", () =>  Results.Content(PagesRepository.Level0, "text/html"));
app.MapGet("/1", () =>  Results.Content(PagesRepository.Level1, "text/html"));

app.MapPost("/click", ([FromForm] int count) => Results.Content(PagesRepository.BuildForm(count + 1), "text/html"))
  .DisableAntiforgery(); // So no token needed

app.MapRazorPages();

//Liftoff
app.Run();
