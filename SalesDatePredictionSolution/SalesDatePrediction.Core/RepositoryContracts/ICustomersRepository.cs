using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.RepositoryContracts;

public interface ICustomersRepository
{
  Task<DbResultsWithPaginationValuesDTO<CustomerOrderPrediction>> 
    GetCustomersWithOrderPredictionsAsync(PaginationDTO paginationDTO);

  Task<Customer?> GetCustomerByIdAsync(int customerId);
}
