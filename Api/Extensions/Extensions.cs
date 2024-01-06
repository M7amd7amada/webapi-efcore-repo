using DataAccess.Data;

using Domain.Helper;
using Domain.Settings;

using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class Extensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        string? connectionString = builder.Configuration.GetConnectionString("LocalhostConStr");

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("SettingsConfiguration"));

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddApiServices();

        return builder;
    }
}