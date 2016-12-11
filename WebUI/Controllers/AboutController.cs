using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.DAO;

namespace WebUI.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            var model = new AboutDAO().getAbout();
            return View(model);
        }
    }
}