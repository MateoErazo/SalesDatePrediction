using Microsoft.Extensions.DependencyInjection;
using SalesDatePrediction.Infrastructure.DbContext;

namespace SalesDatePrediction.Infrastructure;

public static class DependencyInjection
{
  /// <summary>
  /// Extension method to add infrastructure services to the dependency injection container.
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection AddInfrastructure(this IServiceCollection services)
  {
    services.AddTransient<DapperDbContext>();
    return services;
  }
}