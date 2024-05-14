using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication11.Session
{
    public class SessionAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Check if the session variable exists
            if (!context.HttpContext.Session.TryGetValue("UserId", out byte[] value) || value == null)
            {
                // Redirect to the login page or show an unauthorized page
                context.Result = new RedirectResult("/Account/Login");
            }
            else
            {
                // Allow the request to proceed to the action method
                // No action needed here, as the request will naturally continue to the action method
            }
        }
    }
}
