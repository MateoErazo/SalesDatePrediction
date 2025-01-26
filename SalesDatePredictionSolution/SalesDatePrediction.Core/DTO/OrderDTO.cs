namespace SalesDatePrediction.Core.DTO;

public record OrderDTO (
  int Orderid,
  DateTime Requireddate,
  DateTime Shippeddate,
  string? Shipname,
  string? Shipaddress,
  string? Shipcity
  );
