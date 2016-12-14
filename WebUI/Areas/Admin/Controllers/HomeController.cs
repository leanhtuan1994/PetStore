using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Domain.DAO;

namespace WebUI.Areas.Admin.Controllers
{
    public class HomeController : BaseController {
        // GET: Admin/Home
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var model = new OrdersDAO().ListAllPaging(page, pageSize);
            return View(model);
        }
    }
}