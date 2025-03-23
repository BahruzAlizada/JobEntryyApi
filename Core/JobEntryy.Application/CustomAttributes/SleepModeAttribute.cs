
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JobEntryy.Application.CustomAttributes
{
    public class SleepModeAttribute : Attribute, IAsyncActionFilter
    {
        public int StartHour { get; }
        public int EndHour { get; }

        public SleepModeAttribute(int startHour, int endHour)
        {
            StartHour = startHour;
            EndHour = endHour;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var httpMethod = context.HttpContext.Request.Method;
            if (httpMethod != HttpMethods.Get) 
            {
                var currentHour = DateTime.UtcNow.AddHours(4).Hour;

                if ((StartHour > EndHour && (currentHour >= StartHour || currentHour < EndHour)) ||
                    (StartHour <= EndHour && (currentHour >= StartHour && currentHour < EndHour)))
                {
                    context.Result = new ContentResult
                    {
                        Content = "This endpoint is not available during sleep mode.",
                        StatusCode = 403 // Forbidden
                    };

                    return;
                }

            }
            await next();
        }
    }
}
