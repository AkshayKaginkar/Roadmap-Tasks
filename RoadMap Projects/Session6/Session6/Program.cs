


using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Session6.Context;
using Session6.Extensions;
using Session6.Repositories;
using Session6.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string con = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(con), ServiceLifetime.Singleton);
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IProductService, ProductService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks( )  
    .AddCheck<DBHealthCheck>("database")
    .AddCheck<GetAllCheck>("GetAllMethod");



builder.Services.AddHealthChecksUI(opt =>
{
    opt.SetEvaluationTimeInSeconds(15);
    opt.MaximumHistoryEntriesPerEndpoint(60);
    opt.SetApiMaxActiveRequests(1);
    //opt.AddHealthCheckEndpoint("API", "/Healthz");

}).AddInMemoryStorage();


//builder.Services.AddHealthChecksUI().AddInMemoryStorage();
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
