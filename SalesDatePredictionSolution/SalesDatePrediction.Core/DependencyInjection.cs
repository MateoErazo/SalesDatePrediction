﻿using Microsoft.Extensions.DependencyInjection;

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
    return services;
  }
}
