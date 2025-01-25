using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.RepositoryContracts;

public interface ICustomersRepository
{
  Task<List<CustomerOrderPrediction?>> GetCustomersWithOrderPredictionsAsync();
}
