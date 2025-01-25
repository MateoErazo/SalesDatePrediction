using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Infrastructure.DbContext;

namespace SalesDatePrediction.Infrastructure.Repositories;

internal class CustomersRepository : ICustomersRepository
{
  private readonly DapperDbContext _dbContext;

  public CustomersRepository(DapperDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  public async Task<List<CustomerOrderPrediction?>> GetCustomersWithOrderPredictionsAsync()
  {
    throw new NotImplementedException();
  }
}
