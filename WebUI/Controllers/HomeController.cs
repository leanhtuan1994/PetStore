using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.DAO;

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
            ViewBag.ListFeatureProduct = new ProductDAO().ListFeatureProduct(4);
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

        [ChildActionOnly]
        public ActionResult TopMenu() {
            var model = new MenuDAO().ListByGroupID(2);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Footer() {
            var model = new FooterDAO().GetFooter();
            return PartialView(model);
        }




    }
}