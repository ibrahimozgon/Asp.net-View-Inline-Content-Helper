using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;

namespace InlineContentHelper
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteTable.Routes.MapRoute(
                "arabam_default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            DisplayModeProvider.Instance.Modes.Clear();
            var mobile = new DefaultDisplayMode("Mobile")
            {
                ContextCondition = context =>  context.Request.Browser.IsMobileDevice
            };
            DisplayModeProvider.Instance.Modes.Add(mobile);
            DisplayModeProvider.Instance.Modes.Add(new DefaultDisplayMode(""));
        }
    }
}
