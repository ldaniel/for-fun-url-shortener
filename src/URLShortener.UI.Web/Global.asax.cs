using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace URLShortener.UI.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute("Preview", "Preview/{shorturl}",
                                new
                                {
                                    controller = "Home",
                                    action = "Preview",
                                    shorturl = UrlParameter.Optional
                                }
                           );

            routes.MapRoute("HandleForm", "HandleForm/{original}",
                                new
                                {
                                    controller = "Home",
                                    action = "HandleForm"
                                }
                           );

            routes.MapRoute("About", "About",
                                new
                                {
                                    controller = "Home",
                                    action = "About"
                                }
                            );

            routes.MapRoute("Create", "Create",
                                new
                                {
                                    controller = "Home",
                                    action = "Create"
                                }
                            );

            routes.MapRoute("Copy", "Copy",
                            new
                            {
                                controller = "Home",
                                action = "Copy"
                            }
                        );

            routes.MapRoute("ShortUrl", "{shorturl}",
                                new
                                {
                                    controller = "Home",
                                    action = "Index"
                                }
                            );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                                new
                                {
                                    controller = "Home",
                                    action = "Default",
                                    id = UrlParameter.Optional
                                }
                            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
