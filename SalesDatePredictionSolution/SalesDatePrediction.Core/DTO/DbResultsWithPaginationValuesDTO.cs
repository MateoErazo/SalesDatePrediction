namespace SalesDatePrediction.Core.DTO;

public class DbResultsWithPaginationValuesDTO<T>
{
  public int TotalRecordsAmount { get; set; }
  public IEnumerable<T>? DbResults { get; set; }
}
