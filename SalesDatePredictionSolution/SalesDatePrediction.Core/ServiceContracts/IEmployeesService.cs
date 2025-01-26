using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface IEmployeesService
{
  Task<IEnumerable<EmployeeDTO?>> GetAllEmployees();
  Task<EmployeeDTO?> GetEmployeeById(int employeeId);
}
