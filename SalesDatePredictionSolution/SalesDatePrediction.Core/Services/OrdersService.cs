using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Core.ServiceContracts;
using System.Runtime.CompilerServices;

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
  public async Task<OrderCreationResultDTO?> CreateOrder(OrderCreationDTO orderCreationDTO)
  {
    Order order = _mapper.Map<Order>(orderCreationDTO);
    Order? orderCreated = await _ordersRepository.AddOrderAsync(order);

    if (orderCreated == null) return null;

    return _mapper.Map<OrderCreationResultDTO>(orderCreated) 
      with { Success = true};
  }

  public async Task<OrderCreationResultDTO?> CreateOrderWithProduct(OrderWithProductCreationDTO orderWithProductCreation)
  {
    OrderCreationDTO? orderCreationDTO = orderWithProductCreation.Order;

    if(orderCreationDTO == null) return null;

    OrderCreationResultDTO? orderCreationResult = await CreateOrder(orderCreationDTO);

    if (orderCreationResult == null) return null;

    OrderDetails orderDetails = _mapper.Map<OrderDetails>(orderWithProductCreation);
    orderDetails.Orderid = orderCreationResult.Orderid;

    OrderDetails? orderWithProductCreated = 
      await _ordersRepository.AddItemToOrder(orderDetails);

    if (orderWithProductCreated == null) return null;

    return orderCreationResult;
  }

  public async Task<IEnumerable<OrderDTO?>> GetOrdersByCustomerId(int customerId)
  {
    IEnumerable<Order?> orders = 
      await _ordersRepository.GetOrdersByCustomerIdAsync(customerId);

    return _mapper.Map<IEnumerable<OrderDTO?>>(orders);
  }
}
