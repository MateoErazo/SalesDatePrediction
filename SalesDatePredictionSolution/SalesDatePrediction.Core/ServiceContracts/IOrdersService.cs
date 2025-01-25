using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface IOrdersService
{
  Task<IEnumerable<CustomerOrderDTO?>> GetOrdersByCustomerId(int customerId);
  Task CreateOrder(CustomerOrder customerOrder);
}
