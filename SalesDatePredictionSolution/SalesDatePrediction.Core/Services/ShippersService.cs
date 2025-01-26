using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.Core.Services;

internal class ShippersService : IShippersService
{
  private readonly IShippersRepository _shippersRepository;
  private readonly IMapper _mapper;

  public ShippersService(IShippersRepository shippersRepository, IMapper mapper)
  {
    _shippersRepository = shippersRepository;
    _mapper = mapper;
  }
  public async Task<IEnumerable<ShipperDTO?>> GetAllShippers()
  {
    IEnumerable<Shipper?> shippers = await _shippersRepository.GetShippersAsync();

    return _mapper.Map<IEnumerable<ShipperDTO?>>(shippers);
  }

  public async Task<ShipperDTO?> GetShipperById(int shipperId)
  {
    Shipper? shipper = await _shippersRepository.GetShipperByIdAsync(shipperId);

    if(shipper == null) return null;

    return _mapper.Map<ShipperDTO>(shipper);
  }
}
