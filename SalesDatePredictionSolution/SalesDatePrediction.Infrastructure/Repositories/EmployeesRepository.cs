using Dapper;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Infrastructure.DbContext;

namespace SalesDatePrediction.Infrastructure.Repositories;

internal class EmployeesRepository : IEmployeesRepository
{
  private readonly DapperDbContext _dbContext;

  public EmployeesRepository(DapperDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
  {
    string query = @"SELECT 
                  emp.empid AS Empid,
                  CONCAT(emp.firstname,' ', emp.lastname) AS FullName,
                  emp.phone AS Phone,
                  emp.address AS [Address],
                  emp.city AS City,
                  emp.country AS Country
                  FROM HR.Employees emp
                  WHERE emp.empid = @EmployeeId";

    return await _dbContext.DbConnection.QueryFirstOrDefaultAsync<Employee?>(query, new {EmployeeId = employeeId});
  }

  public async Task<IEnumerable<Employee?>> GetEmployeesAsync()
  {
    string query = @"SELECT 
                  emp.empid AS Empid,
                  CONCAT(emp.firstname,' ', emp.lastname) AS FullName
                  FROM
                  HR.Employees emp
                  ORDER BY FullName";

    return await _dbContext.DbConnection.QueryAsync<Employee>(query);
  }
}
