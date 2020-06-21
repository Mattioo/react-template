using Microsoft.AspNetCore.Mvc.Filters;

namespace react_template.Helpers.Filters
{
    public class AppActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // ..
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // ..
        }
    }
}
