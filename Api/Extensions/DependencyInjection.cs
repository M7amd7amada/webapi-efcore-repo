using DataAccess.Data;
using DataAccess.Repositories;

using Domain.Interfaces;

namespace Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}