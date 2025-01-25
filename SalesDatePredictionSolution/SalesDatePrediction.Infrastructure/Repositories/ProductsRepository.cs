using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Infrastructure.DbContext;

namespace SalesDatePrediction.Infrastructure.Repositories;

internal class ProductsRepository : IProductsRepository
{
  private readonly DapperDbContext _dbContext;

  public ProductsRepository(DapperDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  public async Task AddProductAsync(Product product)
  {
    throw new NotImplementedException();
  }

  public async Task<List<Product?>> GetProductsAsync()
  {
    throw new NotImplementedException();
  }
}
