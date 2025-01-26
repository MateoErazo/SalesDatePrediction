using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.Mappers;

public class ProductMappingProfile: Profile
{
  public ProductMappingProfile()
  {
    CreateMap<Product, ProductDTO>();
  }
}
