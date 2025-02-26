using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface IOrdersService
{
  Task<DbResultsWithPaginationValuesDTO<OrderDTO>> GetOrdersByOrderFilter(OrderFilterDTO orderFilter);
  Task<bool> CheckOrderCreationDependenciesExistInDb(OrderCreationDTO orderCreation);
  Task<OrderCreationResultDTO?> CreateOrderWithProduct(OrderWithProductCreationDTO orderWithProductCreation);
}
