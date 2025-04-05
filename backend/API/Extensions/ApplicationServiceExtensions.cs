using Core.Interfases;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using Serilog.Filters;
using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions;
public static class ApplicationServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration) =>
        services.AddCors(options =>
        {
        string[] verbs = new string[] { "GET", "POST", "PUT", "DELETE", "PATCH", "OPTIONS" };
        var origins = configuration.GetSection("CorsSettings:Origins").Get<string[]>(); 
            options.AddPolicy("CorsPolicy", builder =>
                builder.WithOrigins(origins) // frontend's posibles origens [ Develop ]
                    .WithMethods(verbs)
                    .AllowAnyHeader());
        });

    public static void AddAplicacionServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
