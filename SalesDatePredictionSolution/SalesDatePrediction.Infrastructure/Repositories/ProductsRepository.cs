using Dapper;
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

  public async Task<IEnumerable<Product?>> GetProductsAsync()
  {
    string query = @"SELECT
                  prod.productid AS Productid,
                  prod.productname AS Productname
                  FROM
                  Production.Products prod
                  ORDER BY prod.productname";

    return await _dbContext.DbConnection.QueryAsync<Product?>(query);
  }
}
