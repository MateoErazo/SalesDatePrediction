using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.Core.Services;

internal class CustomersService : ICustomersService
{
  private readonly ICustomersRepository _customersRepository;
  private readonly IMapper _mapper;

  public CustomersService(ICustomersRepository customersRepository, 
    IMapper mapper)
  {
    _customersRepository = customersRepository;
    _mapper = mapper;
  }
  public async Task<DbResultsWithPaginationValuesDTO<CustomerOrderPredictionDTO>> GetAllCustomersOrderPredictions(PaginationDTO paginationDTO)
  {

    DbResultsWithPaginationValuesDTO<CustomerOrderPrediction> customerPredictions = 
      await _customersRepository.GetCustomersWithOrderPredictionsAsync(paginationDTO);

    return _mapper.Map<DbResultsWithPaginationValuesDTO<CustomerOrderPredictionDTO>>(customerPredictions);
  }

  public async Task<CustomerDTO?> GetCustomerById(int customerId)
  {
    Customer? customer = await _customersRepository.GetCustomerByIdAsync(customerId);
    return _mapper.Map<CustomerDTO?>(customer);
  }
}
