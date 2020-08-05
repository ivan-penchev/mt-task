using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Shared.Extensions;
namespace Shared.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase<TDbContext>(
              this IServiceCollection services,
             IConfiguration configuration)
              where TDbContext : DbContext
              => services
                  .AddScoped<DbContext, TDbContext>()
                  .AddDbContext<TDbContext>(options => options
                      .UseSqlServer(
                          configuration.GetDefaultConnectionString(),
                          sqlOptions => sqlOptions
                              .EnableRetryOnFailure(
                                  maxRetryCount: 10,
                                  maxRetryDelay: System.TimeSpan.FromSeconds(30),
                                  errorNumbersToAdd: null)));

    }
}
