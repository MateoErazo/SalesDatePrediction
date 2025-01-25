﻿using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.Core.Services;

internal class CustomersService : ICustomersService
{
  private readonly ICustomersRepository _customersRepository;

  public CustomersService(ICustomersRepository customersRepository)
  {
    _customersRepository = customersRepository;
  }
  public async Task<IEnumerable<CustomerOrderPrediction?>> GetAllCustomersOrderPredictions()
  {
    return await _customersRepository.GetCustomersWithOrderPredictionsAsync();
  }
}
