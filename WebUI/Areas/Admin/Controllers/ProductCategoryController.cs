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

namespace WebUI.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        private PetStoreDbContext db = new PetStoreDbContext();
        private ProductCategoryDAO prCateDAO = new ProductCategoryDAO();

        // GET: Admin/ProductCategory
        /// <summary>
        /// Danh Sách Danh mục sản phẩm
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var productCategories = prCateDAO.ListAllPaging(page, pageSize);
            return View(productCategories);
        }

        // GET: Admin/ProductCategory/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(long? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = prCateDAO.GetProductCategoryByID(id);
            if (productCategory == null) {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // GET: Admin/ProductCategory/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        // POST: Admin/ProductCategory/Create
       /// <summary>
       /// 
       /// </summary>
       /// <param name="productCategory"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,ParentID,DisplayOrder,SeoTitle,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription,Status,ShowOnHome")] ProductCategory productCategory)
        {
            if (ModelState.IsValid && prCateDAO.Create(productCategory)) {
                return RedirectToAction("Index");
            }

            SetViewBag(productCategory.ParentID);
            return View(productCategory);
        }

        // GET: Admin/ProductCategory/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(long? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = prCateDAO.GetProductCategoryByID(id);
            if (productCategory == null){
                return HttpNotFound();
            }
            SetViewBag(productCategory.ParentID);
            return View(productCategory);
        }

        // POST: Admin/ProductCategory/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,MetaTitle,ParentID,DisplayOrder,SeoTitle,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription,Status,ShowOnHome")] ProductCategory productCategory)
        {
            if (ModelState.IsValid && prCateDAO.Edit(productCategory) ) {             
                return RedirectToAction("Index");
            }
            SetViewBag(productCategory.ParentID);
            return View(productCategory);
        }

        // GET: Admin/ProductCategory/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(long? id)
        {
            if (id == null)  {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductCategory productCategory = prCateDAO.GetProductCategoryByID(id);
            if (productCategory == null) {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: Admin/ProductCategory/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            prCateDAO.Delete(id);
            return RedirectToAction("Index");
        }

        public void SetViewBag(long? selectedID = null) {
            ViewBag.ParentID = new SelectList(prCateDAO.ListAll(), "ID", "Name", selectedID);
        }

    }
}
