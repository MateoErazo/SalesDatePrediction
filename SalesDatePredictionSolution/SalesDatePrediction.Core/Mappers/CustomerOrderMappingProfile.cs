using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.Mappers;

public class CustomerOrderMappingProfile: Profile
{
  public CustomerOrderMappingProfile() {
    CreateMap<CustomerOrder, CustomerOrderDTO>();
  }
}
