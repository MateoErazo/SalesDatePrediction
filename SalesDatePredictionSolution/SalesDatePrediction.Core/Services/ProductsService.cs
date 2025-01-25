using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.Core.Services;

internal class ProductsService : IProductsService
{
  private readonly IProductsRepository _productsRepository;

  public ProductsService(IProductsRepository productsRepository)
  {
    _productsRepository = productsRepository;
  }
  public async Task CreateProduct(Product product)
  {
    throw new NotImplementedException();
  }

  public async Task<List<Product?>> GetAllProducts()
  {
    throw new NotImplementedException();
  }
}
