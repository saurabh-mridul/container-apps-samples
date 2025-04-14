using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ContainerApps.Functions
{
    public class MockQueueTrigger
    {
        private readonly ILogger<MockQueueTrigger> _logger;
        public MockQueueTrigger(ILogger<MockQueueTrigger> logger)
        {
            _logger = logger;
        }

        [Function(nameof(MockQueueTrigger))]
        public void Run([QueueTrigger("sample-queue", Connection = "ContainerApps")] QueueMessage message)
        {
            _logger.LogInformation($"Mock Queue trigger function processed: {message.MessageText}");
        }
    }
}
