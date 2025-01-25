using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.Mappers;

public class CustomerOrderPredictionMappingProfile : Profile
{
  public CustomerOrderPredictionMappingProfile() {
    CreateMap<CustomerOrderPrediction, CustomerOrderPredictionDTO>();
  }
}
