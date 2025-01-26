namespace SalesDatePrediction.Core.Entities;

public class OrderDetails
{
  public int Orderid { get; set; }
  public int Productid { get; set; }
  public double Unitprice { get; set; }
  public int Qty { get; set; }
  public double Discount { get; set; }
}
