using SalesDatePrediction.Core.DTO;

namespace SalesDatePrediction.Core.Entities;

public class CustomerOrderPrediction
{
  public int CustomerId { get; set; }
  public string? CustomerName { get; set; }
  public DateTime LastOrderDate { get; set; }
  public DateTime NextPredictedOrder {  get; set; }
}
