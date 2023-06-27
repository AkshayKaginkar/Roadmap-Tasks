using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Session6.Controllers;
using Session6.Models;
using Session6.Services;
using System.Diagnostics;

namespace Session6.Extensions
{
    public class GetAllCheck : IHealthCheck
    {
        readonly ProductController productController;
        readonly IProductService productService;

        public GetAllCheck(IProductService _productService)
        {
            productService = _productService;
            productController = new ProductController(productService);
        }
        
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
        {
            
                try
                {
                Stopwatch stopwatch = Stopwatch.StartNew();
                ActionResult result =  productController.Products();
                stopwatch.Stop();
                var duration =stopwatch.Elapsed;
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("duration",duration.TotalSeconds);
                return HealthCheckResult.Healthy($"duration : {data["duration"]} Sec");

                
                }
                catch (Exception ex)
                {
                    return HealthCheckResult.Unhealthy(ex.Message);
                }

            
        }
    }
}
