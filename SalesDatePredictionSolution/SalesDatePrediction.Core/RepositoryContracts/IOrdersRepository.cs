using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.RepositoryContracts;

public interface IOrdersRepository
{
  Task<IEnumerable<CustomerOrder?>> GetOrdersByCustomerIdAsync(int customerId);

  Task AddOrderAsync(CustomerOrder customerOrder);
}
