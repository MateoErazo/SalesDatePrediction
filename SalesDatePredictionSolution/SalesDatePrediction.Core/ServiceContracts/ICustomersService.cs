using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface ICustomersService
{
  Task<List<CustomerOrderPrediction?>> GetAllCustomersOrderPredictions();
}
