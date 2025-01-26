using SalesDatePrediction.Core.Entities;
using System.Data;

namespace SalesDatePrediction.Core.RepositoryContracts;

public interface IOrdersRepository
{
  Task<IEnumerable<Order?>> GetOrdersByCustomerIdAsync(int customerId);

  Task<Order?> AddOrderAsync(Order order, IDbTransaction transaction);
  Task<OrderDetails?> AddItemToOrderAsync(OrderDetails orderDetails, IDbTransaction transaction);
  Task<Order?> AddOrderWithProductAsync(Order order, OrderDetails orderDetails);
}
