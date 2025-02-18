using AutoMapper.Configuration.Annotations;
using Dapper;
using Microsoft.AspNetCore.Http;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Infrastructure.DbContext;
using System.Data;
using System.Data.Common;

namespace SalesDatePrediction.Infrastructure.Repositories;

internal class CustomersRepository : ICustomersRepository
{
  private readonly DapperDbContext _dbContext;

  public CustomersRepository(DapperDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<Customer?> GetCustomerByIdAsync(int customerId)
  {
    string query = @"SELECT
                  cust.custid,
                  cust.companyname,
                  cust.contactname,
                  cust.contacttitle,
                  cust.address,
                  cust.city,
                  cust.region,
                  cust.postalcode,
                  cust.country,
                  cust.phone,
                  cust.fax
                  FROM
                  Sales.Customers cust
                  WHERE cust.custid = @CustomerId";

    return await _dbContext.DbConnection.QueryFirstOrDefaultAsync<Customer>(query, new {CustomerId = customerId});
  }

  public async Task<DbResultsWithPaginationValuesDTO<CustomerOrderPrediction>> 
    GetCustomersWithOrderPredictionsAsync(PaginationDTO paginationDTO)
  {
    string baseQuery = $@"
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
      ";

    string totalRecordsColumn = @"
          SELECT
          COUNT(*) AS TotalRecords
          FROM LastOrders laor
          INNER JOIN Averages avgs ON laor.custid = avgs.custid
          INNER JOIN Sales.Customers cust ON cust.custid = laor.custid";

    string queryColumns = @"
          -- Calculate the next estimated order date for each customer
          SELECT
          cust.custid AS CustomerId,
	        cust.companyname AS CustomerName,
          laor.LastOrderDate AS LastOrderDate,
          DATEADD(DAY, avgs.DaysAverage, laor.LastOrderDate) AS NextPredictedOrder
          FROM LastOrders laor
          INNER JOIN Averages avgs ON laor.custid = avgs.custid
          INNER JOIN Sales.Customers cust ON cust.custid = laor.custid";

    int totalRecords = await _dbContext.DbConnection.ExecuteScalarAsync<int>($"{baseQuery}{totalRecordsColumn}");


    DynamicParameters parameters = new DynamicParameters();

    string paginatedQuery = $"{baseQuery}{queryColumns} ORDER BY laor.LastOrderDate DESC OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
    parameters.Add("Offset", (paginationDTO.Page - 1) * paginationDTO.PageSize);
    parameters.Add("PageSize", paginationDTO.PageSize);
    
    var result = await _dbContext.DbConnection.QueryAsync<CustomerOrderPrediction>(paginatedQuery, parameters);

    return new DbResultsWithPaginationValuesDTO<CustomerOrderPrediction>()
    {
      TotalRecordsAmount = totalRecords,
      DbResults = result
    };
  }
}
