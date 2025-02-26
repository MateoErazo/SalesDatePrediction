using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;
using System.Data;

namespace SalesDatePrediction.Core.RepositoryContracts;

public interface IOrdersRepository
{
  Task<DbResultsWithPaginationValuesDTO<Order>> GetOrdersByOrderFilterAsync(OrderFilterDTO orderFilter);

  Task<Order?> AddOrderAsync(Order order, IDbTransaction transaction);
  Task<OrderDetails?> AddItemToOrderAsync(OrderDetails orderDetails, IDbTransaction transaction);
  Task<Order?> AddOrderWithProductAsync(Order order, OrderDetails orderDetails);
}
