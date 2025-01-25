using Dapper;
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

  public async Task<IEnumerable<CustomerOrder?>> GetOrdersByCustomerIdAsync(int customerId)
  {
    string query = @"SELECT
                  ord.orderid,
                  ord.requireddate,
                  ord.shippeddate,
                  ord.shipname,
                  ord.shipaddress,
                  ord.shipcity
                  FROM
                  Sales.Orders ord
                  WHERE ord.custid = @CustomerId
                  ORDER BY ord.orderid DESC";

    return await _dbContext.DbConnection.QueryAsync<CustomerOrder?>(query, new {CustomerId = customerId});
  }
}
