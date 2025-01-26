using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController: ControllerBase
{
  private readonly IProductsService _productsService;

  public ProductsController(IProductsService productsService)
  {
    _productsService = productsService;
  }

  [HttpGet]
  public async Task<IEnumerable<ProductDTO?>> GetAllProducts()
  {
    return await _productsService.GetAllProducts();
  }
}
