namespace SalesDatePrediction.Core.DTO;

public record CustomerOrderDTO (
  int Orderid,
  DateTime Requireddate,
  DateTime Shippeddate,
  string? Shipname,
  string? Shipaddress,
  string? Shipcity
  );
