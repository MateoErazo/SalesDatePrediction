namespace SalesDatePrediction.API.Utilities;

internal static class PaginationOperations
{
  public static int CalculatePagesAmount(int totalCount, int pageSize)
  {
    return (int)Math.Ceiling((double)totalCount / pageSize);
  }
}
