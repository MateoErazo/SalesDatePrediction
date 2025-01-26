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
  public async Task<Order?> AddOrderAsync(Order order)
  {
    string query = @"INSERT INTO Sales.Orders 
                  (empid, 
                   shipperid, 
                   shipname, 
                   shipaddress, 
                   shipcity, 
                   orderdate, 
                   requireddate, 
                   shippeddate, 
                   freight, 
                   shipcountry)
                  VALUES (@Empid, @Shipperid, @Shipname, @Shipaddress, 
                          @Shipcity, @Orderdate, @Requireddate, @Shippeddate, 
                          @Freight, @Shipcountry);";

    int amountRowsAffected = await _dbContext.DbConnection.ExecuteAsync(query, order);

    if (amountRowsAffected <= 0) { return  null; }

    return order;
  }

  public async Task<IEnumerable<Order?>> GetOrdersByCustomerIdAsync(int customerId)
  {
    string query = @"SELECT
                  ord.orderid,
                  ord.orderdate,
                  ord.empid,
                  ord.requireddate,
                  ord.shipperid,
                  ord.shippeddate,
                  ord.shipname,
                  ord.shipaddress,
                  ord.shipcity,
                  ord.shipcountry,
                  ord.freight
                  FROM
                  Sales.Orders ord
                  WHERE ord.custid = @CustomerId
                  ORDER BY ord.orderid DESC";

    return await _dbContext.DbConnection.QueryAsync<Order?>(query, new {CustomerId = customerId});
  }
}
