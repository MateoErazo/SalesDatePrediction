using SalesDatePrediction.Core.DTO;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface ICustomersService
{
  Task<IEnumerable<CustomerOrderPredictionDTO?>> GetAllCustomersOrderPredictions();
}
