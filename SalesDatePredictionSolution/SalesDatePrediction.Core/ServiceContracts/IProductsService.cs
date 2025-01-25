using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface IProductsService
{
  Task<List<Product?>> GetAllProducts();
  Task CreateProduct(Product product);
}
