using Microsoft.Extensions.DependencyInjection;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Infrastructure.DbContext;
using SalesDatePrediction.Infrastructure.Repositories;

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
    services.AddTransient<ICustomersRepository, CustomersRepository>();
    services.AddTransient<IEmployeesRepository, EmployeesRepository>();
    services.AddTransient<IOrdersRepository, OrdersRepository>();
    services.AddTransient<IProductsRepository, ProductsRepository>();
    services.AddTransient<IShippersRepository, ShippersRepository>();

    services.AddTransient<DapperDbContext>();
    return services;
  }
}