using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Infrastructure.DbContext;

namespace SalesDatePrediction.Infrastructure.Repositories;

internal class OrdersRepository : IOrdersRepository
{
  private readonly DapperDbContext _dbContext;

  public OrdersRepository(DapperDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  public async Task AddOrderAsync(CustomerOrder customerOrder)
  {
    throw new NotImplementedException();
  }

  public async Task<List<CustomerOrder?>> GetOrdersByCustomerIdAsync(int customerId)
  {
    throw new NotImplementedException();
  }
}
