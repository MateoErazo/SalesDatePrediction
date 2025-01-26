using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.RepositoryContracts;

public interface IShippersRepository
{
  Task<IEnumerable<Shipper?>> GetShippersAsync();
}
