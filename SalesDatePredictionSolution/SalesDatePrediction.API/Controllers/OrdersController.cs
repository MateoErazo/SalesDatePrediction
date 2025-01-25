using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController: ControllerBase
{
  private readonly IOrdersService _ordersService;

  public OrdersController(IOrdersService ordersService)
  {
    _ordersService = ordersService;
  }

  [HttpGet("customers/{customerId:int}")]
  public async Task<IEnumerable<CustomerOrderDTO?>> GetCustomerOrdersByCustomerId(int customerId)
  {
    return await _ordersService.GetOrdersByCustomerId(customerId);
  } 
}
