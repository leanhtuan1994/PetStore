using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.DAO;
using WebUI.Common;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Slides = new SlideDAO().ListAll();
            ViewBag.ListNewProduct = new ProductDAO().ListNewProduct(6);
            ViewBag.ListFeatureCollections = new ProductDAO().Listfeadturecollections();
            return View();
        }

        /// <summary>
        /// Main Menu
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult MainMenu() {
            var model = new MenuDAO().ListByGroupID(1);
            ViewBag.ProductCategory = new ProductCategoryDAO().ListAll();
            return PartialView(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult TopMenu() {
            var model = new MenuDAO().ListByGroupID(2);
            return PartialView(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Footer() {
            var model = new FooterDAO().GetFooter();
            return PartialView(model);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult HeaderCart() {
            var cart = Session[CommonConstant.CART_SESSION];
            var listCart = new List<CartItem>();
            if (cart != null) {
                listCart = (List<CartItem>)cart;
            }

            decimal total = 0;
            foreach(var item in listCart) {
                total += (item.Product.Price * item.Quantity).Value;
            }
            ViewBag.total = total;

            return PartialView(listCart);
        }


    }
}