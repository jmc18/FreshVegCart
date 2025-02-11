using FreshVegCart.Api.Data;
using FreshVegCart.Api.Data.Repositories;
using FreshVegCart.Api.Interfaces.Persistence;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


#region Scoped Services

builder.Services.AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IOrderRepository, OrderRepository>()
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<IOrderItemRepository, OrderItemRepository>()
    .AddScoped<IUserAddressRepository, UserAddressRepository>()
    .AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

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
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
