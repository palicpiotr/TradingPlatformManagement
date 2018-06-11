using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TradingPlatformManagement.App_Start;

namespace TradingPlatformManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.ConfigureDI();
        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            { }
        }

        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode == 302 && Context.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                Context.Response.Clear();
                Context.Response.StatusCode = 401;
                Context.Response.StatusDescription = "Authentication required";
            }
        }
    }
}
