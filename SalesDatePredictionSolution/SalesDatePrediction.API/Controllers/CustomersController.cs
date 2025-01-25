using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.DTO;
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
  public async Task<IEnumerable<CustomerOrderPredictionDTO?>> GetAllCustomersWithOrdersPredictions()
  {
    return await _customersService.GetAllCustomersOrderPredictions();
  }

}
