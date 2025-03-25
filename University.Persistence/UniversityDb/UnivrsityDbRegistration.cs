using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace University.Persistence.UniversityDb;

public static class UniversityDbContextRegistration
{
    public static void RegisterUniversityDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("UniversityDb");

        services.AddDbContext<UniversityDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        UniversityDbContext.UniversityMigrationHistory,
                        UniversityDbContext.UniversityDbSchema);
                });
        });
    }
}
