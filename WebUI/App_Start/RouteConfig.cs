using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
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

            // Trang giới thiệu 
            routes.MapRoute(
               name: "About",
               url: "gioi-thieu",
               defaults: new {
                   controller = "About", action = "Index", id = UrlParameter.Optional
               },
               namespaces: new[] { "WebUI.Controllers" }
           );

            //Trang giỏ hàng
            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new {
                    controller = "Cart", action = "Index", id = UrlParameter.Optional
                },
                namespaces: new[] { "WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "Payment",
               url: "thanh-toan",
               defaults: new {
                   controller = "Cart", action = "Payment", id = UrlParameter.Optional
               },
               namespaces: new[] { "WebUI.Controllers" }
           );


            routes.MapRoute(
               name: "OrderSuccess",
               url: "hoan-thanh",
               defaults: new {
                   controller = "Cart", action = "OrderSuccess", id = UrlParameter.Optional
               },
               namespaces: new[] { "WebUI.Controllers" }
           );

            // Controller liên hệ
            routes.MapRoute(
              name: "Contact",
              url: "lien-he",
              defaults: new {
                  controller = "Contact", action = "Index", id = UrlParameter.Optional
              },
              namespaces: new[] { "WebUI.Controllers" }
          );

            // Controller tin tức
            routes.MapRoute(
              name: "ContentCategory",
              url: "tin-tuc",
              defaults: new {
                  controller = "Content", action = "ContentCategory", id = UrlParameter.Optional
              },
              namespaces: new[] { "WebUI.Controllers" }
          );

            // Controller tin tức
            routes.MapRoute(
              name: "Content Detail",
              url: "tin-tuc/{metatitle}-{id}",
              defaults: new {
                  controller = "Content", action = "ContentDetail", id = UrlParameter.Optional
              },
              namespaces: new[] { "WebUI.Controllers" }
          );

            // Routing tới Controller User - Register.
            routes.MapRoute(
             name: "Register",
             url: "dang-ky",
             defaults: new {
                 controller = "User", action = "Register", id = UrlParameter.Optional
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
