using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.EF;
using Domain.DAO;
using PagedList;

namespace WebUI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private ProductDAO productDAO = new ProductDAO();
        private ProductCategoryDAO productCategoryDAO = new ProductCategoryDAO();

        // GET: Admin/Product
        public ActionResult Index(int page = 1, int pageSize = 10){
            var products = productDAO.ListAllPaging(page, pageSize);
            return View(products);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productDAO.GetByID(id);
            if (product == null){
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Name,Code,Description,MetaTitle,Image,MoreImages,Price,PromotionPrice,Quantity,CategoryID,Detail,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription,Status,ViewCount")] Product product)
        {
            if (ModelState.IsValid && productDAO.Create(product)) {              
                return RedirectToAction("Index");
            }

            SetViewBag(product.CategoryID);
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)    {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productDAO.GetByID(id);
            if (product == null){
                return HttpNotFound();
            }
            SetViewBag(product.CategoryID);
            return View(product);
        }

        // POST: Admin/Product/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Name,Code,Description,MetaTitle,Image,MoreImages,Price,PromotionPrice,Quantity,CategoryID,Detail,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription,Status,ViewCount")] Product product)
        {
            if (ModelState.IsValid)  {
                productDAO.Edit(product);
                return RedirectToAction("Index");
            }
            
            SetViewBag(product.CategoryID);
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)  {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productDAO.GetByID(id);
            if (product == null) {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            productDAO.Delete(id);
            return RedirectToAction("Index");
        }


        public void SetViewBag(long? selectedID = null) {
            ViewBag.CategoryID = new SelectList(productCategoryDAO.ListAll(), "ID", "Name", selectedID);
        }

    }
}
