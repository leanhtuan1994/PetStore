using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.DAO;
using PagedList;

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

        /// <summary>
        ///  Trang hiển thị danh sách sản phẩm theo danh mục
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Category(long id, int page = 1, int pageSize = 9) {
            var product = new ProductDAO().ListOfCategory(id, page, pageSize);
            return View(product);     
        }

         /// <summary>
         ///  Trang hiển thi danh sách tất cả sản phẩm 
         /// </summary>
         /// <returns></returns>
        public ActionResult ListCategory(int page = 1, int pageSize = 9) {
            var model = new ProductDAO().ListAllPaging(page, pageSize);
            ViewBag.ListCategory = new ProductCategoryDAO().ListAll();
            return View(model);
        }

        /// <summary>
        ///  Trang chi tiết sản phẩm 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(long id) {
            var model = new ProductDAO().GetByID(id);
            return View(model);
        }

        /// <summary>
        ///    Tạo Partial view cho menu trái
        /// </summary>
        /// <returns></returns>
        /// 
        [ChildActionOnly]
        public ActionResult LeftMenu() {
            var model = new ProductCategoryDAO().ListAll();
            ViewBag.ListTag = new TagDAO().ListAll();
            ViewBag.ListFeatureProduct = new ProductDAO().ListFeatureProduct(1);
            return PartialView(model);
        }
    }
}