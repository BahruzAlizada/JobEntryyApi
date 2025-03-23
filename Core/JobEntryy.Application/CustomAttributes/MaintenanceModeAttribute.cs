using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JobEntryy.Application.CustomAttributes
{
    public class MaintenanceModeAttribute : Attribute, IAsyncActionFilter
    {
        private readonly bool IsMaintenanceMode;
        public MaintenanceModeAttribute(bool IsMaintenanceMode)
        {
            this.IsMaintenanceMode = IsMaintenanceMode;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (IsMaintenanceMode)
            {
                context.Result = new ContentResult
                {
                    Content = "This service is currently under maintenance. Please try again later.",
                    StatusCode = 503
                };
                return;
            }
            await next();
        }
    }
}
