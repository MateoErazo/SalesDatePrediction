namespace SalesDatePrediction.Core.DTO;

public record OrderCreationResultDTO (
  bool Success,
  int Orderid,
  int Empid,
  int Shipperid,
  string? Shipname,
  string? Shipaddress,
  string? Shipcity,
  DateTime Orderdate,
  DateTime Requireddate,
  DateTime Shippeddate,
  double Freight,
  string? Shipcountry
  )
{
  public OrderCreationResultDTO()
    :this(default,default,default,default,default,default,
       default, default, default, default, default,default) { }
};
