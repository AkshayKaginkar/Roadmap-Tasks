using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Session6HealthCheck.Check;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string con = builder.Configuration.GetConnectionString("default");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
.AddCheck<DBHealthCheck>("database");
/*.AddCheck(builder.Configuration.GetConnectionString("default"), tags: new[]
{
    "db","all"
})
.AddUrlGroup(new Uri("http://localhost:7198/healtz"), tags: new[]
{
    "weatherApi","all"
});*/

//builder.Services.AddHealthChecksUI().AddInMemoryStorage();

builder.Services.AddHealthChecksUI(opt =>
{
    opt.SetEvaluationTimeInSeconds(15); //time in seconds between check
    opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
    opt.SetApiMaxActiveRequests(1); //api requests concurrency
    opt.AddHealthCheckEndpoint("API", "/WeatherForcast"); //map health check api
}).AddInMemoryStorage();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse

});


app.MapHealthChecksUI();

app.Run();
