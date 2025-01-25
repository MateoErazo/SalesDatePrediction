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

  public CustomersService(ICustomersRepository customersRepository, IMapper mapper)
  {
    _customersRepository = customersRepository;
    _mapper = mapper;
  }
  public async Task<IEnumerable<CustomerOrderPredictionDTO?>> GetAllCustomersOrderPredictions()
  {
    IEnumerable<CustomerOrderPrediction?> predictions = 
      await _customersRepository.GetCustomersWithOrderPredictionsAsync();

    return _mapper.Map<IEnumerable<CustomerOrderPredictionDTO?>>(predictions);
  }
}
