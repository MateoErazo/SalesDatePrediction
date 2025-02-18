namespace SalesDatePrediction.API.Utilities;

public static class HttpContextExtensions
{
  public static void InsertParameterInHeader(
    this HttpContext httpContext,
    string parameterName, 
    string parameterValue)
  {
    httpContext.Response.Headers.Append(parameterName, parameterValue);
  }
}
