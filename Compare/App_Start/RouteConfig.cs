using System.Web.Mvc;
using System.Web.Routing;

namespace Site.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Compare", // Route name
                "{controller}/Compare/{tag1}/{tag2}", // URL with parameters
                new {controller = "Home", action = "Compare", tag1 = "", tag2 = ""} // Parameter defaults
                );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );


        }
    }
}