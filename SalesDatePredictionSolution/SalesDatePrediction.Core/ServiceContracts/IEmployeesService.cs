using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface IEmployeesService
{
  Task<List<Employee?>> GetAllEmployees();
}
