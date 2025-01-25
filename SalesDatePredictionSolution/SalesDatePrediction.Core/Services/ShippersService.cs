using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.Core.Services;

internal class ShippersService : IShippersService
{
  private readonly IShippersRepository _shippersRepository;

  public ShippersService(IShippersRepository shippersRepository)
  {
    _shippersRepository = shippersRepository;
  }
  public async Task<List<Shipper?>> GetAllShippers()
  {
    throw new NotImplementedException();
  }
}
