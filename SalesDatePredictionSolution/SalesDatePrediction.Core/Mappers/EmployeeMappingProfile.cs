using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.Mappers;

public class EmployeeMappingProfile : Profile
{
  public EmployeeMappingProfile() {
    CreateMap<Employee, EmployeeDTO>();
  }
}
