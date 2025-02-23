﻿using SalesDatePrediction.Core.DTO;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface IShippersService
{
  Task<IEnumerable<ShipperDTO?>> GetAllShippers();
  Task<ShipperDTO?> GetShipperById(int shipperId);
}
