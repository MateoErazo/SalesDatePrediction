using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface ICustomersService
{
  Task<IEnumerable<CustomerOrderPrediction?>> GetAllCustomersOrderPredictions();
}
