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
  public async Task<List<Employee?>> GetEmployeesAsync()
  {
    throw new NotImplementedException();
  }
}
