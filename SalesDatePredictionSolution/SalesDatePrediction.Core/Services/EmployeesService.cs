using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.Core.Services;

internal class EmployeesService : IEmployeesService
{
  private readonly IEmployeesRepository _employeesRepository;

  public EmployeesService(IEmployeesRepository employeesRepository)
  {
    _employeesRepository = employeesRepository;
  }
  public async Task<List<Employee?>> GetAllEmployees()
  {
    throw new NotImplementedException();
  }
}
