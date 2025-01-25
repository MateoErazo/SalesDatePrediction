using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.Core.Services;

internal class OrdersService : IOrdersService
{
  private readonly IOrdersRepository _ordersRepository;
  private readonly IMapper _mapper;

  public OrdersService(IOrdersRepository ordersRepository, IMapper mapper)
  {
    _ordersRepository = ordersRepository;
    _mapper = mapper;
  }
  public async Task CreateOrder(CustomerOrder customerOrder)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<CustomerOrderDTO?>> GetOrdersByCustomerId(int customerId)
  {
    IEnumerable<CustomerOrder?> orders = 
      await _ordersRepository.GetOrdersByCustomerIdAsync(customerId);

    return _mapper.Map<IEnumerable<CustomerOrderDTO?>>(orders);
  }
}
