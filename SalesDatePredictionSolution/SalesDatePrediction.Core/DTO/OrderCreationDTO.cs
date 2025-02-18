namespace SalesDatePrediction.Core.DTO;
public record OrderCreationDTO (
  int Custid,
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
  );
