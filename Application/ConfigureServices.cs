using System.Reflection;
using Application.UseCases.Services.Db;
using Application.UseCases.Services.Db.Interfaces;
using Application.UseCases.Services.Game;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static void InjectionApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IActionService, ActionService>();
        services.AddScoped<ICharacterService, CharacterService>();
        
        services.AddScoped<DoActionService>();
    }
}