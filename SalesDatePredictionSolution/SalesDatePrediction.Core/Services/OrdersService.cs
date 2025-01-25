using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.Core.Services;

internal class OrdersService : IOrdersService
{
  private readonly IOrdersRepository _ordersRepository;

  public OrdersService(IOrdersRepository ordersRepository)
  {
    _ordersRepository = ordersRepository;
  }
  public async Task CreateOrder(CustomerOrder customerOrder)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<CustomerOrder?>> GetOrdersByCustomerId(int customerId)
  {
    return await _ordersRepository.GetOrdersByCustomerIdAsync(customerId);
  }
}
