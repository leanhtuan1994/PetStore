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
    public class AboutController : BaseController
    {
        private AboutDAO aboutDAO = new AboutDAO();

        // GET: Admin/About
        public ActionResult Index()
        {
            return View(aboutDAO.ListAll());
        }

        // GET: Admin/About/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = aboutDAO.GetByID(id);
            if (about == null){
                return HttpNotFound();
            }
            return View(about);
        }

        // GET: Admin/About/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/About/Create
        /// <summary>
        /// 
        /// </summary>
        /// <param name="about"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,MetaTitle,Image,Detail,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription,Status")] About about)
        {
            if (ModelState.IsValid && aboutDAO.Create(about)) {     
                return RedirectToAction("Index");
            }

            return View(about);
        }

        // GET: Admin/About/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = aboutDAO.GetByID(id);
            if (about == null){
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Admin/About/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="about"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,MetaTitle,Image,Detail,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription,Status")] About about)
        {
            if (ModelState.IsValid && aboutDAO.Edit(about)) {            
                return RedirectToAction("Index");
            }
            return View(about);
        }

        // GET: Admin/About/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = aboutDAO.GetByID(id);
            if (about == null){
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Admin/About/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            aboutDAO.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
