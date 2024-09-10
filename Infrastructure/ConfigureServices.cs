using Application.Interfaces.Repositories;
using Infrastructure.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace Infrastructure;

public static class ConfigureServices
{
    public static void InjectionInfrastructure(this IServiceCollection services, string? connectionString)
    {
        services.AddScoped<IUnitOfWork>(_ =>
        {
            var connection = new MySqlConnection(connectionString);
            
            return new UnitOfWork(connection);
        });
    }
}