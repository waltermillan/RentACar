using API.Extensions;
using API.Profiles;
using API.Services;
using Core.Interfases;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

string appName = builder.Configuration["SystemName:Name"] ?? "App";

// Clear other logging providers
builder.Logging.ClearProviders();

// Configure logging filters for ASP.NET Core and Entity Framework Core
builder.Logging.AddFilter("Microsoft", LogLevel.Warning);
builder.Logging.AddFilter("System", LogLevel.Warning);

// Configuring Serilog to write to file only
Log.Logger = new LoggerConfiguration()
    .WriteTo.File($"logs/{appName}-.log", rollingInterval: RollingInterval.Day) // Log in daily archive
    .Filter.ByExcluding(Matching.FromSource("Microsoft.EntityFrameworkCore")) // Exclude logs from Entity Framework Core
    .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore")) // Exclude logs from ASP.NET Core
    .CreateLogger();

builder.Logging.AddSerilog(); // Add Serilog as a log provider


builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IRentRepository, RentRepository>();
builder.Services.AddScoped<IPayTypeRepository, PayTypeRepository>();
builder.Services.AddScoped<IPriceRepository, PriceRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserDTOService>();
builder.Services.AddScoped<RentDTOService>();

// Add services to the container.
builder.Services.ConfigureCors(builder.Configuration);
builder.Services.AddAplicacionServices();
builder.Services.AddControllers();

builder.Services.AddDbContext<Context>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("RentACarConnection");
    options.UseSqlite(connectionString);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<Context>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Ocurrió un error durante la migración");
    }
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();