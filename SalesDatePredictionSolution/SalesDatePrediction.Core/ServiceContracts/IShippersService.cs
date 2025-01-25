using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface IShippersService
{
  Task<List<Shipper?>> GetAllShippers();
}
