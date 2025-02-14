using API.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Serilog;
using Infrastructure.Logging;
using Serilog.Filters;
using API.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Limpiar otros proveedores de logging
builder.Logging.ClearProviders();

// Configurar filtros de logging para ASP.NET Core y Entity Framework Core
builder.Logging.AddFilter("Microsoft", LogLevel.Warning); // Para toda la parte de Microsoft
builder.Logging.AddFilter("System", LogLevel.Warning); // Para logs de System

// Configuración de Serilog para escribir solo en archivo
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/todolist-.log", rollingInterval: RollingInterval.Day) // Log en archivo diario
    .Filter.ByExcluding(Matching.FromSource("Microsoft.EntityFrameworkCore")) // Excluir logs de Entity Framework Core
    .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore")) // Excluir logs de ASP.NET Core
    .CreateLogger();

builder.Logging.AddSerilog(); // Agregar Serilog como proveedor de logs


builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));  // Asegúrate de registrar el perfil


// Add services to the container.
builder.Services.ConfigureCors();
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