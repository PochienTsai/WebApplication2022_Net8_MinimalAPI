var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//=================================================
var app = builder.Build();

// Configure the HTTP request pipeline.

//app.MapGet("/",() => "Hello, The World");

//app.MapGet("/users/{userId}/books/{bookId}",
//    (int userId, int bookId) => $"The user id is {userId} and book id is {bookId}");


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// 以前controller 的HttpGet
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
