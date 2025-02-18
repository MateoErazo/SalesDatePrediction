namespace SalesDatePrediction.Core.DTO;

public record CustomerOrderPredictionDTO(
  int CustomerId,
  string? CustomerName,
  DateTime LastOrderDate,
  DateTime NextPredictedOrder
  );
