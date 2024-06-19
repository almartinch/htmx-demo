//Dependencies
using Microsoft.AspNetCore.Mvc;

//Setup
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();

//Routes
app.MapGet("/", () => Results.Content(Pages.Home, "text/html"));
app.MapGet("/0", () =>  Results.Content(Pages.Level0, "text/html"));
app.MapGet("/1", () =>  Results.Content(Pages.Level1, "text/html"));

app.MapPost("/click", ([FromForm] int count) => Results.Content(Pages.BuildForm(count + 1), "text/html"))
  .DisableAntiforgery(); // So no token needed

//Liftoff
app.Run();
