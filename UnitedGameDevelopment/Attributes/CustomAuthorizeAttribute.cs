namespace UnitedGameDevelopment.Web.Attributes
{
    using System.Linq;
    using System.Web.Mvc;

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            var roles = this.Roles.Split(',');

            if (filterContext.HttpContext.Request.IsAuthenticated 
                && !roles.Any(filterContext.HttpContext.User.IsInRole))
                filterContext.Result = new ViewResult() { ViewName = "~/Views/Shared/Unauthorized.cshtml" };
            else
                base.HandleUnauthorizedRequest(filterContext);
        }
    }
}