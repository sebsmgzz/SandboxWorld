using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AzureFunctionAppOptionsPatternDemo
{
    public class MyFunction
    {

        private readonly ILogger<MyFunction> logger;
        private readonly IMyService myService;

        public MyFunction(
            ILogger<MyFunction> logger, 
            IMyService myService)
        {
            this.logger = logger;
            this.myService = myService;
        }

        [FunctionName(nameof(MyFunction))]
        public async Task<IActionResult> Run(
            [HttpTrigger(
                authLevel: AuthorizationLevel.Anonymous,
                methods: new string[] { "get" }, 
                Route = null)] 
            HttpRequest request,
            ILogger logger)
        {
            myService.PrintValue(logger);
            return new OkObjectResult(myService.GetJsonValue());
        }
    }
}
