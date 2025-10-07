using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPostgreDbContext<TContext>(
        this IServiceCollection services,
        string configurationPath = "dbconnpostgresql")
        where TContext : DbContext
    {
        return services.AddDbContext<TContext>((sp, options) => {
            var config = sp.GetRequiredService<IConfiguration>();
            var connectionString = config.GetValue<string>(configurationPath);
            //var connectionString = config[configurationPath];

            Console.WriteLine("Check connectionStirng...");
            Console.WriteLine(connectionString);
            options.UseNpgsql(connectionString);
        });
    }
}