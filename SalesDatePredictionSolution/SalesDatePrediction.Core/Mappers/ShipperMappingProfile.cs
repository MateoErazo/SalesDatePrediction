using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.Mappers;

public class ShipperMappingProfile : Profile
{
  public ShipperMappingProfile() {
    CreateMap<Shipper, ShipperDTO>();
  }
}
