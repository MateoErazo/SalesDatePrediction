namespace SalesDatePrediction.Core.DTO;

public class PaginationDTO
{
  private int page = 1;
  private readonly int minimumPage = 1;
  public int Page {
    get { return page; }
    set { page = (value < minimumPage) ? minimumPage : value; }
  }

  private int pageSize = 1;
  private readonly int minimumPageSize = 1;
  private readonly int maximumPageSize = 50;
  public int PageSize
  {
    get { return pageSize; }
    set {
      if (value > maximumPageSize)
        pageSize = maximumPageSize;
      else if (value < minimumPageSize)
        pageSize = minimumPageSize;
      else
        pageSize = value;
    }
  }
}
