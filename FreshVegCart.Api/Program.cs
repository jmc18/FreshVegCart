using FluentValidation;
using FreshVegCart.Api.Data;
using FreshVegCart.Api.Data.Repositories;
using FreshVegCart.Api.Interfaces.Persistence;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<FreshVegCartDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#region Scoped Services

builder.Services.AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IOrderRepository, OrderRepository>()
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<IOrderItemRepository, OrderItemRepository>()
    .AddScoped<IUserAddressRepository, UserAddressRepository>()
    .AddScoped<IUnitOfWork, UnitOfWork>();

#endregion
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<FreshVegCartDbContext>();
    var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
    if (pendingMigrations.Any())
        await context.Database.MigrateAsync();
}

app.UseHttpsRedirection();


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
