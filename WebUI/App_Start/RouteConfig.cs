﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

          
           
            // Routing cho danh mục sản phẩm
            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{metatitle}-{id}",
                defaults: new {
                    controller = "Product", action = "Category", id = UrlParameter.Optional
                },
                namespaces: new[] { "WebUI.Controllers" }
            );

            routes.MapRoute(
              name: "Product ListCategory",
              url: "san-pham",
              defaults: new {
                  controller = "Product", action = "ListCategory", id = UrlParameter.Optional
              },
              namespaces: new[] { "WebUI.Controllers" }
          );

            // Routing chi tiết sản phẩm
            routes.MapRoute(
               name: "Product Detail",
               url: "chi-tiet/{metatitle}-{id}",
               defaults: new {
                   controller = "Product", action = "Detail", id = UrlParameter.Optional
               },
               namespaces: new[] { "WebUI.Controllers" }
           );

            routes.MapRoute(
               name: "About",
               url: "gioi-thieu",
               defaults: new {
                   controller = "About", action = "Index", id = UrlParameter.Optional
               },
               namespaces: new[] { "WebUI.Controllers" }
           );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new {
                   controller = "Home", action = "Index", id = UrlParameter.Optional
               },
               namespaces: new[] { "WebUI.Controllers" }
           );

        }
    }
}
