using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface IOrdersService
{
  Task CreateOrder(CustomerOrder customerOrder);
}
