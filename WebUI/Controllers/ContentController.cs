using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.DAO;

namespace WebUI.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult ContentDetail(long id)
        {
            return View();
        }

        public ActionResult ContentCategory() {

            var model = new ContentDAO().ListAll();
            return View(model);
        }
    }
}