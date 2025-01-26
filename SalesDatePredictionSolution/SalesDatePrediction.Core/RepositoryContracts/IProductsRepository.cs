using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.RepositoryContracts;

public interface IProductsRepository
{
  Task<IEnumerable<Product?>> GetProductsAsync();

  Task<Product?> GetProductByIdAsync(int productId);
}
