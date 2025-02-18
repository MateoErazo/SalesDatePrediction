

namespace SalesDatePrediction.Core.Entities;

public class Order
{
  public int Orderid { get; set; }
  public int Custid {  get; set; }
  public DateTime Orderdate { get; set; }
  public int Empid { get; set; }
  public DateTime Requireddate { get; set; }
  public int Shipperid {  get; set; } 
  public DateTime Shippeddate { get; set; }
  public string? Shipname { get; set; }
  public string? Shipaddress { get; set; }
  public string? Shipcountry { get; set; }
  public decimal Freight { get; set; }
  public string? Shipcity { get; set; }
}
