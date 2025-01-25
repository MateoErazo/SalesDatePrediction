using Microsoft.AspNetCore.Mvc;

namespace SalesDatePrediction.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController:ControllerBase
{
  public CustomersController() { }

  [HttpGet]
  public async Task<IActionResult> GetCustomers()
  {
    return Ok(new {
      Message = "All working fine",
      State = "success"
    });
  }

}
