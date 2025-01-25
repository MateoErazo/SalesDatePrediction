using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController: ControllerBase
{
  private readonly IEmployeesService _employeesService;

  public EmployeesController(IEmployeesService employeesService)
  {
    _employeesService = employeesService;
  }

  [HttpGet]
  public async Task<IEnumerable<EmployeeDTO?>> GetAllEmployees()
  {
    return await _employeesService.GetAllEmployees();
  }
}
