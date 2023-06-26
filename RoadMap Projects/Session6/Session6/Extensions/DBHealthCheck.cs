using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Session6.Extensions
{
    public class DBHealthCheck : IHealthCheck
    {
        private readonly IConfiguration _configuration;

        public DBHealthCheck(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("default");

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using var command = connection.CreateCommand();
                    command.CommandText = "Select 1";
                    command.ExecuteScalar();
                    return HealthCheckResult.Healthy();
                }
            }
            catch (Exception ex)
            {
                 return HealthCheckResult.Unhealthy(ex.Message);
            }
        }
    }
}
