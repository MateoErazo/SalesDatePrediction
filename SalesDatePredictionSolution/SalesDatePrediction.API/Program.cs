using SalesDatePrediction.API.Middlewares;
using SalesDatePrediction.Core;
using SalesDatePrediction.Core.Mappers;
using SalesDatePrediction.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add Controllers to the service collection
builder.Services.AddControllers();

//CORS
builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(corsOptions =>
  {
    corsOptions.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
  });
});

builder.Services.AddAutoMapper(typeof(CustomerOrderPredictionMappingProfile).Assembly);

//Build the web application
var app = builder.Build();

//Global exception handler
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller Routes
app.MapControllers();
app.Run();
