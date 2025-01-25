using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.RepositoryContracts;

public interface IProductsRepository
{
  Task<List<Product?>> GetProductsAsync();

  Task AddProductAsync(Product product);
}
