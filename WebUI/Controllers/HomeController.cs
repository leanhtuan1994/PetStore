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
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Main Menu
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult MainMenu() {
            var model = new MenuDAO().ListByGroupID(1);
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