using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface IOrdersService
{
  Task<IEnumerable<OrderDTO?>> GetOrdersByCustomerId(int customerId);
  Task<bool> CheckOrderCreationDependenciesExistInDb(OrderCreationDTO orderCreation);
  Task<OrderCreationResultDTO?> CreateOrderWithProduct(OrderWithProductCreationDTO orderWithProductCreation);
}
