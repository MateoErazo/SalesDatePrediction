using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.API.Utilities;
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
  public async Task<IEnumerable<CustomerOrderPredictionDTO?>> 
    GetAllCustomersWithOrdersPredictions([FromQuery] PaginationDTO pagination)
  {
    DbResultsWithPaginationValuesDTO<CustomerOrderPredictionDTO> result = 
      await _customersService.GetAllCustomersOrderPredictions(pagination);

    int pagesAmount = PaginationOperations.CalculatePagesAmount(result.TotalRecordsAmount, pagination.PageSize);

    HttpContext.InsertParameterInHeader("total-records-amount", result.TotalRecordsAmount.ToString());
    HttpContext.InsertParameterInHeader("pages-amount",pagesAmount.ToString());
    
    return result.DbResults;
  }

}
