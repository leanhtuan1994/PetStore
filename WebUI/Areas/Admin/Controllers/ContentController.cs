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
    public class ContentController : BaseController
    {
        private ContentDAO contentDAO = new ContentDAO();
        private CategoryDAO categoryDAO = new CategoryDAO();

        // GET: Admin/Content
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var content = contentDAO.ListAllPaging(page, pageSize);
            return View(content);
        }

        // GET: Admin/Content/Details/5
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
            Content content = contentDAO.GetByID(id);
            if (content == null)           {
                return HttpNotFound();
            }
            return View(content);
        }

        // GET: Admin/Content/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        // POST: Admin/Content/Create
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Name,Description,MetaTitle,Image,CategoryID,Detail,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription,Status,ViewCount,Tags")] Content content)
        {
            if (ModelState.IsValid && contentDAO.Create(content)) {             
                return RedirectToAction("Index");
            }

            SetViewBag(content.CategoryID);
            return View(content);
        }

        // GET: Admin/Content/Edit/5
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
            Content content = contentDAO.GetByID(id);
            if (content == null)   {
                return HttpNotFound();
            }
            SetViewBag(content.CategoryID);
            return View(content);
        }

        // POST: Admin/Content/Edit/5
       /// <summary>
       /// 
       /// </summary>
       /// <param name="content"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,MetaTitle,Image,CategoryID,Detail,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription,Status,ViewCount,Tags")] Content content)
        {
            if (ModelState.IsValid && contentDAO.Edit(content)){             
                return RedirectToAction("Index");
            }
            SetViewBag(content.CategoryID);
            return View(content);
        }

        // GET: Admin/Content/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = contentDAO.GetByID(id);
            if (content == null)  {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: Admin/Content/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            contentDAO.Delete(id);
            return RedirectToAction("Index");
        }

        public void SetViewBag(long? selectedID = null) {
            ViewBag.CategoryID = new SelectList(categoryDAO.ListAll(), "ID", "Name", selectedID);
        }
    }
}
