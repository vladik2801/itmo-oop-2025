using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Options;
using Lab5.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AdminOptions>(configuration.GetSection("Admin"));
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ISessionService, SessionService>();

        return services;
    }
}