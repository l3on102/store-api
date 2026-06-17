var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/weatherforecast", () => "hello store api");

app.Run();

