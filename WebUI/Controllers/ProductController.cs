using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.DAO;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult ProductCategory() {
            var model = new ProductCategoryDAO().ListAll();
            return PartialView(model);
        }

        public ActionResult Category(long id) {
            var category = new ProductCategoryDAO().GetProductCategoryByID(id);
            return View(category);     
        }

        public ActionResult Detail(long id) {
            var model = new ProductDAO().GetByID(id);
            return View(model);
        }
    }
}