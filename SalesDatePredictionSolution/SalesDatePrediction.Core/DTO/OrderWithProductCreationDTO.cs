using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Core.DTO;

public record OrderWithProductCreationDTO(
  OrderCreationDTO? Order,
  int Productid,
  double Unitprice, 
  int Qty, 
  double Discount
  );
