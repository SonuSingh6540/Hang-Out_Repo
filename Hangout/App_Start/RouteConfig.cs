using System.Web.Mvc;
using System.Web.Routing;

namespace Hangout
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Content", action = "Create", id = UrlParameter.Optional }
            );
        }
    }
}
