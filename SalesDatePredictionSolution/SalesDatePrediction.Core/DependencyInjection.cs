using Microsoft.Extensions.DependencyInjection;
using SalesDatePrediction.Core.ServiceContracts;
using SalesDatePrediction.Core.Services;

namespace SalesDatePrediction.Core;

public static class DependencyInjection
{
  /// <summary>
  /// Extension method to add core services to the dependency injection container.
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection AddCore(this IServiceCollection services)
  {
    services.AddTransient<ICustomersService, CustomersService>();
    services.AddTransient<IEmployeesService, EmployeesService>();
    services.AddTransient<IOrdersService, OrdersService>();
    services.AddTransient<IProductsService, ProductsService>();
    services.AddTransient<IShippersService, ShippersService>();
    return services;
  }
}
