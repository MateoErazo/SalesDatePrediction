using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.API.Utilities;
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

  [HttpGet("customers/filters")]
  public async Task<IEnumerable<OrderDTO?>> GetCustomerOrdersByCustomerId([FromQuery] OrderFilterDTO orderFilter)
  {
    DbResultsWithPaginationValuesDTO<OrderDTO> result = 
      await _ordersService.GetOrdersByOrderFilter(orderFilter);

    int pagesAmount = PaginationOperations.CalculatePagesAmount(result.TotalRecordsAmount, orderFilter.PageSize);

    HttpContext.InsertParameterInHeader("total-records-amount", result.TotalRecordsAmount.ToString());
    HttpContext.InsertParameterInHeader("pages-amount", pagesAmount.ToString());


    return result.DbResults;
  }

  [HttpPost]
  public async Task<OrderCreationResultDTO?> CreateOrderWithProduct([FromBody] OrderWithProductCreationDTO orderWithProduct)
  {
    return await _ordersService.CreateOrderWithProduct(orderWithProduct);
  }
}
