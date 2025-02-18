using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Core.Mappers
{
  public class DbResultsWithPaginationValuesMappingProfile: Profile
  {
    public DbResultsWithPaginationValuesMappingProfile() {
      CreateMap<DbResultsWithPaginationValuesDTO<CustomerOrderPrediction>, 
        DbResultsWithPaginationValuesDTO<CustomerOrderPredictionDTO>>();
    }
  }
}
