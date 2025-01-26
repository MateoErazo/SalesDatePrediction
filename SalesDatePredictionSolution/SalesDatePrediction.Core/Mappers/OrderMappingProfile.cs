using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.Mappers;

public class OrderMappingProfile: Profile
{
  public OrderMappingProfile() {
    CreateMap<Order, OrderDTO>();
    CreateMap<OrderCreationDTO, Order>();
    CreateMap<Order, OrderCreationResultDTO>();
  }
}
