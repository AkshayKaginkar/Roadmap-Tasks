


namespace Session6.Extensions
{
    public static class HealthcheckExtensionRegistration
    {/*
            public static IServiceCollection AddHealthcheckExtensionService(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddHealthChecks()
                .AddSqlServer(configuration["ConnectionStrings:default"],TagHelperServicesExtensions )
                .AddUrlGroup(new Uri("http://localhost:61948/healthz"))
                .WithTags(new[] { "db", "all" }, "SqlServer") // Add tags to the SQL Server health check
                .WithTags(new[] { "weatherApi", "all" }, "UrlGroup"); 

            //adding healthchecks UI
            services.AddHealthChecksUI(opt =>
                {
                    opt.SetEvaluationTimeInSeconds(15); //time in seconds between check
                    opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
                    opt.SetApiMaxActiveRequests(1); //api requests concurrency
                    opt.AddHealthCheckEndpoint("API", "/healthz"); //map health check api
                }).AddSqlServerStorage(configuration["ConnectionStrings:HealthCheckConnectionString"]);
                return services;
            }
   */ }
    
}
