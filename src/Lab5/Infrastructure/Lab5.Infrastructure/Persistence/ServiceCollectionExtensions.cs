using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastructure.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IAccountRepository, AccountRepository>();
        services.AddSingleton<IUserSessionRepository, UserSessionRepository>();
        services.AddSingleton<IAdminSessionRepository, AdminSessionRepository>();
        services.AddSingleton<IOperationHistoryRepository, OperationHistoryRepository>();
        services.AddSingleton<IPersistenceContext, PersistenceContext>();

        return services;
    }
}