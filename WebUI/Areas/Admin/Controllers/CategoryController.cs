using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.EF;
using PagedList;
using Domain.DAO;

namespace WebUI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private CategoryDAO categoryDAO = new CategoryDAO();

        // GET: Admin/Category
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult Index(int page = 1, int pageSize = 10){
            return View(categoryDAO.ListAllPaging(page, pageSize));
        }

        // GET: Admin/Category/Details/5
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
            Category category = categoryDAO.GetByID(id);
            if (category == null)     {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Category/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(){
            SetViewBag();
            return View();
        }

        // POST: Admin/Category/Create
       /// <summary>
       /// 
       /// </summary>
       /// <param name="category"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,ParentID,DisplayOrder,SeoTitle,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription,Status,ShowOnHome")] Category category)
        {
            if (ModelState.IsValid && categoryDAO.Create(category) ) {             
                return RedirectToAction("Index");
            }

            SetViewBag(category.ParentID);
            return View(category);
        }

        // GET: Admin/Category/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(long? id)
        {
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryDAO.GetByID(id);
            if (category == null)        {
                return HttpNotFound();
            }
            SetViewBag(category.ParentID);
            return View(category);
        }

        // POST: Admin/Category/Edit/5
       /// <summary>
       /// 
       /// </summary>
       /// <param name="category"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,MetaTitle,ParentID,DisplayOrder,SeoTitle,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription,Status,ShowOnHome")] Category category)
        {
            if (ModelState.IsValid && categoryDAO.Edit(category)){            
                return RedirectToAction("Index");
            }
            SetViewBag(category.ParentID);
            return View(category);
        }

        // GET: Admin/Category/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(long? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryDAO.GetByID(id);
            if (category == null)  {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Category/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id) {
            categoryDAO.Delete(id);
            return RedirectToAction("Index");
        }

        public void SetViewBag(long? selectedID = null) {
            ViewBag.ParentID = new SelectList(categoryDAO.ListAll(), "ID", "Name", selectedID);
        }
    }
}
