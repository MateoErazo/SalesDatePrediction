﻿using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.ServiceContracts;

public interface IProductsService
{
  Task<IEnumerable<ProductDTO?>> GetAllProducts();
  Task<ProductDTO?> GetProductById(int productId);
}
