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
  private readonly IProductsRepository _productsRepository;
  private readonly IEmployeesRepository _employeesRepository;
  private readonly IShippersRepository _shippersRepository;
  private readonly IMapper _mapper;

  public OrdersService(
    IOrdersRepository ordersRepository,
    IProductsRepository productsRepository,
    IEmployeesRepository employeesRepository,
    IShippersRepository shippersRepository,
    IMapper mapper)
  {
    _ordersRepository = ordersRepository;
    _productsRepository = productsRepository;
    _employeesRepository = employeesRepository;
    _shippersRepository = shippersRepository;
    _mapper = mapper;
  }
  public async Task<OrderCreationResultDTO?> CreateOrder(OrderCreationDTO orderCreationDTO)
  {
    if (orderCreationDTO == null) return null;

    Employee? employee = await _employeesRepository.GetEmployeeByIdAsync(orderCreationDTO.Empid);
    if (employee == null) return null;

    Shipper? shipper = await _shippersRepository.GetShipperByIdAsync(orderCreationDTO.Shipperid);
    if (shipper == null) return null;

    Order order = _mapper.Map<Order>(orderCreationDTO);
    Order? orderCreated = await _ordersRepository.AddOrderAsync(order);

    if (orderCreated == null) return null;

    return _mapper.Map<OrderCreationResultDTO>(orderCreated) 
      with { Success = true};
  }

  public async Task<OrderCreationResultDTO?> CreateOrderWithProduct(OrderWithProductCreationDTO orderWithProductCreation)
  {
    if (orderWithProductCreation == null) return null;

    Product? product = await _productsRepository.GetProductByIdAsync(orderWithProductCreation.Productid);

    if (product == null) return null;

    OrderCreationDTO? orderCreationDTO = orderWithProductCreation.Order;

    if(orderCreationDTO == null) return null;

    OrderCreationResultDTO? orderCreationResult = await CreateOrder(orderCreationDTO);

    if (orderCreationResult == null) return null;

    OrderDetails orderDetails = _mapper.Map<OrderDetails>(orderWithProductCreation);
    orderDetails.Orderid = orderCreationResult.Orderid;

    OrderDetails? orderWithProductCreated =
      await _ordersRepository.AddItemToOrderAsync(orderDetails);

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
