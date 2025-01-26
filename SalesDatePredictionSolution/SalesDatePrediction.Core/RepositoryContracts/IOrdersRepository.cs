using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.RepositoryContracts;

public interface IOrdersRepository
{
  Task<IEnumerable<Order?>> GetOrdersByCustomerIdAsync(int customerId);

  Task<Order?> AddOrderAsync(Order order);

  Task<OrderDetails?> AddItemToOrderAsync(OrderDetails orderDetails); 
}
