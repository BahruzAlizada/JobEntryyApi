using JobEntryy.Domain.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JobEntryy.Application.CustomAttributes
{
    public class DeletePermissionAttribute : Attribute, IAsyncActionFilter
    {
        private readonly UserManager<AppUser> userManager;
        public DeletePermissionAttribute(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var httpMethod = context.HttpContext.Request.Method;
            if (httpMethod == HttpMethods.Delete)
            {
                var isAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
                if (isAuthenticated)
                {
                    if (context.HttpContext.User.Identity.Name == "bahruzalizada")
                    {

                    }
                }
            }
        }
    }
}
