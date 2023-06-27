


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Session6.Context;

namespace Session6.Extensions
{
    public static class HealthcheckExtensionRegistration
    {
        /*
        public static IServiceCollection AddHealthcheckExtensionService(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddHealthChecks()
                        .AddDbContextCheck<ApplicationDbContext>(name: "Application DB Context", failureStatus: HealthStatus.Degraded)
                        .

            services.AddHealthChecks()
            .AddSqlServer(configuration.GetConnectionString("Default", tags: new[] {
                "db",
                "all"})
            .AddUrlGroup(new Uri("http://localhost:7198/healthz"), tags: new[] {
                "weatherApi",
                "all"
            }));

            services.AddHealthChecks();

            //adding healthchecks UI
            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(15); //time in seconds between check
                opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
                opt.SetApiMaxActiveRequests(1); //api requests concurrency
                opt.AddHealthCheckEndpoint("API", "/healthz"); //map health check api
            }).AddSqlServerStorage(configuration["ConnectionStrings:HealthCheckConnectionString"]);
            return services;
        }*/
    }
    
}
