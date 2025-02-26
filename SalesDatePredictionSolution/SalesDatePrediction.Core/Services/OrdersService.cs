using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Core.ServiceContracts;
using System.Runtime.CompilerServices;

namespace SalesDatePrediction.Core.Services;

internal class OrdersService : IOrdersService
{
  private readonly ICustomersRepository _customersRepository;
  private readonly IOrdersRepository _ordersRepository;
  private readonly IProductsRepository _productsRepository;
  private readonly IEmployeesRepository _employeesRepository;
  private readonly IShippersRepository _shippersRepository;
  private readonly IMapper _mapper;

  public OrdersService(
    ICustomersRepository customersRepository,
    IOrdersRepository ordersRepository,
    IProductsRepository productsRepository,
    IEmployeesRepository employeesRepository,
    IShippersRepository shippersRepository,
    IMapper mapper)
  {
    _customersRepository = customersRepository;
    _ordersRepository = ordersRepository;
    _productsRepository = productsRepository;
    _employeesRepository = employeesRepository;
    _shippersRepository = shippersRepository;
    _mapper = mapper;
  }

  public async Task<OrderCreationResultDTO?> 
    CreateOrderWithProduct(OrderWithProductCreationDTO orderWithProductCreation)
  {
    if (orderWithProductCreation == null) return null;

    Product? product = await _productsRepository
      .GetProductByIdAsync(orderWithProductCreation.Productid);

    if (product == null) return null;

    OrderCreationDTO? orderCreationDTO = orderWithProductCreation.Order;

    if(orderCreationDTO == null) return null;

    bool isCorrectOrder = await CheckOrderCreationDependenciesExistInDb(orderCreationDTO);
    if (!isCorrectOrder) return null;

    Order order = _mapper.Map<Order>(orderCreationDTO);
    OrderDetails orderDetails = _mapper.Map<OrderDetails>(orderWithProductCreation);

    Order? orderCreated = 
      await _ordersRepository.AddOrderWithProductAsync(order,orderDetails);

    if (orderCreated == null) return null;

    return _mapper.Map<OrderCreationResultDTO>(orderCreated)
      with { Success = true };
  }

  public async Task<DbResultsWithPaginationValuesDTO<OrderDTO>> GetOrdersByOrderFilter(OrderFilterDTO orderFilter)
  {
    DbResultsWithPaginationValuesDTO<Order> orders = 
      await _ordersRepository.GetOrdersByOrderFilterAsync(orderFilter);

    return _mapper.Map<DbResultsWithPaginationValuesDTO<OrderDTO>>(orders);
  }

  public async Task<bool> CheckOrderCreationDependenciesExistInDb(OrderCreationDTO orderCreationDTO)
  {
    if (orderCreationDTO == null) return false;

    if(orderCreationDTO.Custid != 0)
    {
      Customer? customer = await _customersRepository.GetCustomerByIdAsync(orderCreationDTO.Custid);
      if (customer == null) return false;
    }

    Employee? employee = await _employeesRepository.GetEmployeeByIdAsync(orderCreationDTO.Empid);
    if (employee == null) return false;

    Shipper? shipper = await _shippersRepository.GetShipperByIdAsync(orderCreationDTO.Shipperid);
    if (shipper == null) return false;

    return true;
  }
}
