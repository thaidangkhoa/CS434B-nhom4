using System.Web;
using System.Web.Mvc;

namespace GymManagement.Filters
{
    public class AuthorizeRoleAttribute : AuthorizeAttribute
    {
        private readonly string _role;

        public AuthorizeRoleAttribute(string role)
        {
            _role = role;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var userRole = httpContext.Session["Role"]?.ToString();
            return !string.IsNullOrEmpty(userRole) && userRole == _role;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Account/Login");
        }
    }
}
