using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetApi.Filters
{
    public class LogSensitiveActionAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Sensitive Action executed !!!!");
            //context.Result = new UnauthorizedResult();
        }
    }
}
