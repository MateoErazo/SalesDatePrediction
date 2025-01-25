using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.Core.Services;

internal class EmployeesService : IEmployeesService
{
  private readonly IEmployeesRepository _employeesRepository;
  private readonly IMapper _mapper;

  public EmployeesService(IEmployeesRepository employeesRepository, IMapper mapper)
  {
    _employeesRepository = employeesRepository;
    _mapper = mapper;
  }
  public async Task<IEnumerable<EmployeeDTO?>> GetAllEmployees()
  {
    IEnumerable<Employee?> employees = 
      await _employeesRepository.GetEmployeesAsync();

    return _mapper.Map<IEnumerable<EmployeeDTO?>>(employees);
  }
}
