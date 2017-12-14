using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace InlineContentHelper.Helpers
{
    public class ViewHelper
    {
        public static bool IsMobile(HttpContextBase httpContext)
        {
            return DisplayMode(httpContext) == "Mobile";
        }
        private static string DisplayMode(HttpContextBase httpContext)
        {
            var mode = DisplayModeProvider.Instance.Modes.FirstOrDefault(t => t.CanHandleContext(httpContext));
            return mode == null ? string.Empty : mode.DisplayModeId;
        }
    }
}