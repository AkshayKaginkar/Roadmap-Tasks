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
        readonly IProductService productService;
        
        public GetAllCheck(IProductService _productService)
        {
            productService = _productService;
            
        }
        
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
        {
            
                try
                {
                ProductController productController = new ProductController(productService);
                ActionResult result =  productController.Products();
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("duration",productController.getAllResponseTime.TotalSeconds);
                var hits = ProductController.getAllHits;
                return HealthCheckResult.Healthy($"Hits : {hits}");

                
                }
                catch (Exception ex)
                {
                    return HealthCheckResult.Unhealthy(ex.Message);
                }

            
        }
    }
}
