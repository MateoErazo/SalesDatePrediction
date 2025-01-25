
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace SalesDatePrediction.Infrastructure.DbContext;

internal class DapperDbContext
{
  private readonly IConfiguration _configuration;
  private readonly IDbConnection _connection;

  public DapperDbContext(IConfiguration configuration)
  {
    _configuration = configuration;
    string? connectionString = _configuration.GetConnectionString("SQLServerConnection");

    //Create a new sql connection with the retrieved connection string
    _connection = new SqlConnection(connectionString);
  }

  public IDbConnection DbConnection => _connection;
}
