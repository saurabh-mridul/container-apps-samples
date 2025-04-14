using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ContainerApps.Functions
{
    public class MockHttpTrigger
    {
        private readonly ILogger<MockHttpTrigger> _logger;

        public MockHttpTrigger(ILogger<MockHttpTrigger> logger)
        {
            _logger = logger;
        }

        [Function("MockHttpTrigger")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            _logger.LogInformation("Mock HTTP trigger function processed a request !!! ");
            return new OkObjectResult("Welcome to Azure Functions - HTTP Trigger");
        }
    }
}
