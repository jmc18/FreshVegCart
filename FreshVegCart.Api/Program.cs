using FluentValidation;
using FreshVegCart.Api.Data;
using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Data.Repositories;
using FreshVegCart.Api.Endpoints;
using FreshVegCart.Api.Interfaces.Persistence;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;
using FreshVegCart.Api.Interfaces.Services;
using FreshVegCart.Api.Services;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using FreshVegCart.Api.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FreshVegCart API",
        Version = "v1",
        Description = "API for managing products, orders, and users in FreshVegCart."
    });
});


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


builder.Services.Configure<JsonOptions>(options =>
    options.SerializerOptions.DefaultIgnoreCondition =
        JsonIgnoreCondition.WhenWritingNull);

builder.Services.AddCors();

#region Transient Services

builder.Services.AddTransient<IAuthService, AuthService>()
    .AddTransient<IProductService, ProductService>()
    .AddTransient<IOrderService, OrderService>()
    .AddTransient<IUserService, UserService>()
    .AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

#endregion


builder.Services.AddOptions<JwtConfig>().BindConfiguration("Jwt");

var jwtConfig = builder.Configuration.GetSection("Jwt").Get<JwtConfig>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig!.SecretKey!)),
        ValidateIssuer = true,
        ValidIssuer = jwtConfig.Issuer,
        ValidateAudience = false,
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FreshVegCart API v1");
    });
}



// global cors policy
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<FreshVegCartDbContext>();
    var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
    if (pendingMigrations.Any())
        await context.Database.MigrateAsync();
}


app.UseHttpsRedirection();

app.UseAuthentication().UseAuthorization();

#region Set Endpoints


app.MapGet("/", () => "FreshVegCart API V1.0");

app.MapProductEndpoints().MapOrderEndpoints().MapUserEndpoints().MapAuthEndpoints();
#endregion



app.Run();