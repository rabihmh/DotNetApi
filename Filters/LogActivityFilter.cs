using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetApi.Filters
{
    public class LogActivityFilter:IActionFilter
    {
        private readonly ILogger _logger;

        public LogActivityFilter(ILogger logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }
    }
}
