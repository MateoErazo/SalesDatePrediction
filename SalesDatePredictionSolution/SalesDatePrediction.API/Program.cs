using SalesDatePrediction.Core;
using SalesDatePrediction.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add Controllers to the service collection
builder.Services.AddControllers();
var app = builder.Build();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller Routes
app.MapControllers();
app.Run();
