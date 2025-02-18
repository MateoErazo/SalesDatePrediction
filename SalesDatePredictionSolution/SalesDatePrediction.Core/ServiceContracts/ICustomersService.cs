using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface ICustomersService
{
  Task<DbResultsWithPaginationValuesDTO<CustomerOrderPredictionDTO>> 
    GetAllCustomersOrderPredictions(PaginationDTO paginationDTO);

  Task<CustomerDTO?> GetCustomerById(int customerId);
}
