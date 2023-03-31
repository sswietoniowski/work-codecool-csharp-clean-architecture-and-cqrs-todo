using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TodoApp.Application.Contracts.Repositories;
using TodoApp.Infrastructure.Configurations;
using TodoApp.Infrastructure.Repositories;

namespace TodoApp.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var databaseEngine = configuration.GetValue<DatabaseEngine>("DatabaseEngine");

        if (databaseEngine == DatabaseEngine.Sqlite)
        {
            services.AddDbContext<SqliteTodoContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("SqliteConnection"));
            });
            services.AddScoped<BaseTodoContext>(provider => provider.GetRequiredService<SqliteTodoContext>());
        }
        else if (databaseEngine == DatabaseEngine.Mssql)
        {
            services.AddDbContext<MssqlTodoContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MssqlConnection"));
            });
            services.AddScoped<BaseTodoContext>(provider => provider.GetRequiredService<MssqlTodoContext>());
        }
        else
        {
            throw new InvalidOperationException("Invalid database engine");
        }

        services.AddScoped<ITodoRepository, TodoRepository>();

        return services;
    }
}