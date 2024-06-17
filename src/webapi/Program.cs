var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello ゴジラ (Godzilla)!");

app.Run();
