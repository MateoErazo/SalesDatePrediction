namespace SalesDatePrediction.Core.DTO;

public record CustomerOrderPredictionDTO(
  string? CustomerName,
  DateTime LastOrderDate,
  DateTime NextPredictedOrder
  );
