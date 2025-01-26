using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.RepositoryContracts;

public interface IProductsRepository
{
  Task<IEnumerable<Product?>> GetProductsAsync();

  Task AddProductAsync(Product product);
}
