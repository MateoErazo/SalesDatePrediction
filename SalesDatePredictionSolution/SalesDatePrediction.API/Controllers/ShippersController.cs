using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShippersController:ControllerBase
{
  private readonly IShippersService _shippersService;

  public ShippersController(IShippersService shippersService)
  {
    _shippersService = shippersService;
  }

  [HttpGet]
  public async Task<IEnumerable<ShipperDTO?>> GetAllShippers()
  {
    return await _shippersService.GetAllShippers();
  }
}
