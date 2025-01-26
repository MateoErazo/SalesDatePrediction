using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.RepositoryContracts;

public interface IEmployeesRepository
{
  Task<IEnumerable<Employee?>> GetEmployeesAsync();
  Task<Employee?> GetEmployeeByIdAsync(int employeeId);
}
