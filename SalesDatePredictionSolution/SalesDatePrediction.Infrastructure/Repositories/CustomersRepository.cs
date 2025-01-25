using Dapper;
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
  public async Task<IEnumerable<CustomerOrderPrediction?>> 
    GetCustomersWithOrderPredictionsAsync()
  {
    string query = @"
      -- Calculate the intervals between orders for each customer
      WITH Intervals AS (
          SELECT 
	      ord.custid,
          DATEDIFF(DAY, LAG(ord.orderdate) OVER (PARTITION BY ord.custid ORDER BY ord.orderdate), ord.orderdate) AS DaysBetweenOrders
          FROM Sales.Orders ord
      ),

      -- Calculate the average number of days between orders per customer
      Averages AS (
          SELECT 
          intv.custid,
	      AVG(intv.DaysBetweenOrders) AS DaysAverage
          FROM Intervals intv
          WHERE intv.DaysBetweenOrders IS NOT NULL -- Excluir registros sin intervalo
          GROUP BY intv.custid
      ),

      -- Get the date of the last order per customer
      LastOrders AS (
          SELECT 
          ord.custid,
          MAX(ord.orderdate) AS LastOrderDate
          FROM Sales.Orders ord
          GROUP BY ord.custid
      )

      -- Calculate the next estimated order date for each customer
          SELECT
	        cust.companyname AS CustomerName,
          laor.LastOrderDate AS LastOrderDate,
          DATEADD(DAY, avgs.DaysAverage, laor.LastOrderDate) AS NextPredictedOrder
          FROM LastOrders laor
          INNER JOIN Averages avgs ON laor.custid = avgs.custid
          INNER JOIN Sales.Customers cust ON cust.custid = laor.custid
          ORDER BY laor.custid;
      ";

    return await _dbContext.DbConnection.QueryAsync<CustomerOrderPrediction>(query);
  }
}
