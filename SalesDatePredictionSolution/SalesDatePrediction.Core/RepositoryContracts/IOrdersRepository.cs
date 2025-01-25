using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.RepositoryContracts;

public interface IOrdersRepository
{
  Task<List<CustomerOrder?>> GetOrdersByCustomerIdAsync(int customerId);

  Task AddOrderAsync(CustomerOrder customerOrder);
}
