using Dapper;
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
  public async Task<IEnumerable<Shipper?>> GetShippersAsync()
  {
    string query = @"SELECT
                  ship.shipperid AS Shipperid,
                  ship.companyname AS Companyname
                  FROM
                  Sales.Shippers ship
                  ORDER BY ship.companyname";

    return await _dbContext.DbConnection.QueryAsync<Shipper>(query);
  }
}
