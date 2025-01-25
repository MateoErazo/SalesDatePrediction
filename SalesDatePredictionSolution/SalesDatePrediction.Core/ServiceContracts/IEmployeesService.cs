using SalesDatePrediction.Core.DTO;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface IEmployeesService
{
  Task<IEnumerable<EmployeeDTO?>> GetAllEmployees();
}
