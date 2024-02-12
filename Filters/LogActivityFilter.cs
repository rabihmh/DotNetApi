using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetApi.Filters
{
    public class LogActivityFilter:IActionFilter
    {
        private readonly ILogger<LogActivityFilter> _logger;

        public LogActivityFilter(ILogger<LogActivityFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
            _logger.LogInformation($"Executing action {context.ActionDescriptor.DisplayName} on controller {context.Controller} with arguments {JsonSerializer.Serialize(context.ActionArguments)}");
            //context.Result = new NotFoundResult();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} finish execution on controller {context.Controller}");
        }
    }
}
