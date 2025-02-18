using Dapper;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Infrastructure.DbContext;
using System.Data;

namespace SalesDatePrediction.Infrastructure.Repositories;

internal class OrdersRepository : IOrdersRepository
{
  private readonly DapperDbContext _dbContext;

  public OrdersRepository(DapperDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<OrderDetails?> 
    AddItemToOrderAsync(OrderDetails orderDetails, IDbTransaction transaction)
  {
    string query = @"INSERT INTO Sales.OrderDetails 
                  (orderid, productid, unitprice, qty, discount)
                  VALUES (@Orderid, @Productid, @Unitprice, @Qty, @Discount);";

    int amountRowsAffected = await _dbContext.DbConnection.ExecuteAsync(query, orderDetails, transaction);

    if (amountRowsAffected <= 0) { return null; }

    return orderDetails;
  }

  public async Task<Order?> AddOrderAsync(Order order, IDbTransaction transaction)
  {
    string customerId = "null";

    if (order.Custid != 0)
    {
      customerId = "@Custid";
    }
    
    string query = $@"INSERT INTO Sales.Orders 
                  (
                   custid,
                   empid, 
                   shipperid, 
                   shipname, 
                   shipaddress, 
                   shipcity, 
                   orderdate, 
                   requireddate, 
                   shippeddate, 
                   freight, 
                   shipcountry)
                  OUTPUT INSERTED.orderid
                  VALUES ({customerId}, @Empid, @Shipperid, @Shipname, @Shipaddress, 
                          @Shipcity, @Orderdate, @Requireddate, @Shippeddate, 
                          @Freight, @Shipcountry);";

    int orderId = await _dbContext.DbConnection.ExecuteScalarAsync<int>(query, order, transaction);

    if (orderId == 0) { return  null; }

    order.Orderid = orderId;
    return order;
  }

  public async Task<Order?> AddOrderWithProductAsync(Order order, OrderDetails orderDetails)
  {
    //Start Transaction
    _dbContext.DbConnection.Open();
    using var transaction = _dbContext.DbConnection.BeginTransaction();
    
    try
    {
      Order? orderCreated = await AddOrderAsync(order, transaction);

      if (orderCreated == null) {
        transaction.Rollback();
        return null;
      }

      orderDetails.Orderid = orderCreated.Orderid;
      OrderDetails? OrderWithProductAdded = await AddItemToOrderAsync(orderDetails, transaction);

      if (OrderWithProductAdded == null)
      {
        transaction.Rollback();
        return null;
      }

      transaction.Commit();
      return orderCreated;
      //End Transaction
    }
    catch (Exception ex) {
      //Reverse transaction
      transaction.Rollback();
      return null;
    }
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
