using DataAccess.Data;

using Domain.Interfaces;

using Microsoft.AspNetCore.Mvc.Infrastructure;

using Takid.Api.Common.Errors;

namespace Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddSingleton<ProblemDetailsFactory, AppProblemDetailsFactory>();

        return services;
    }
}