using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.RepositoryContracts;

public interface IEmployeesRepository
{
  Task<List<Employee?>> GetEmployeesAsync();
}
