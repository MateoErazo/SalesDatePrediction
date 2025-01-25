using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface IOrdersService
{
  Task<IEnumerable<CustomerOrder?>> GetOrdersByCustomerId(int customerId);
  Task CreateOrder(CustomerOrder customerOrder);
}
