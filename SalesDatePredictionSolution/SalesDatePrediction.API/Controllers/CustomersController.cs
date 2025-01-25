using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController:ControllerBase
{
  private readonly ICustomersService _customersService;

  public CustomersController(ICustomersService customersService)
  {
    _customersService = customersService;
  }

  [HttpGet("order-predictions")]
  public async Task<IEnumerable<CustomerOrderPrediction?>> GetAllCustomersWithOrdersPredictions()
  {
    return await _customersService.GetAllCustomersOrderPredictions();
  }

}
