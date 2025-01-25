using SalesDatePrediction.Core;
using SalesDatePrediction.Core.Mappers;
using SalesDatePrediction.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add Controllers to the service collection
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(CustomerOrderMappingProfile).Assembly);

var app = builder.Build();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller Routes
app.MapControllers();
app.Run();
