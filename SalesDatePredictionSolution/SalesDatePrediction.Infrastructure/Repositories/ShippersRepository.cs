using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Infrastructure.DbContext;

namespace SalesDatePrediction.Infrastructure.Repositories;

internal class ShippersRepository : IShippersRepository
{
  private readonly DapperDbContext _dbContext;

  public ShippersRepository(DapperDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  public async Task<List<Shipper?>> GetShippersAsync()
  {
    throw new NotImplementedException();
  }
}
