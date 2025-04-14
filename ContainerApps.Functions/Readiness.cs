using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ContainerApps.Functions
{
    public class Readiness
    {
        private readonly ILogger<Readiness> logger;

        public Readiness(ILogger<Readiness> logger)
        {
            this.logger = logger;
        }

        [Function("Readiness")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest request)
        {
            logger.LogInformation("Checking readiness...", request);
            try
            {
                var randomCounter = Random.Shared.Next(1, 99);
                var isConnected = randomCounter > 30;
                if (isConnected)
                {
                    logger.LogError("Redis connection is not ready.");
                    return new StatusCodeResult(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Redis connection error: {ex.Message}");
                return new StatusCodeResult(StatusCodes.Status503ServiceUnavailable);
            }

            return new OkObjectResult("Ready");
        }
    }
}
