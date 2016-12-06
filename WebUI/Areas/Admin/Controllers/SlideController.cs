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
    public class SlideController : BaseController
    {
        private SlideDAO slideDAO = new SlideDAO();

        // GET: Admin/Slide
        public ActionResult Index()
        {
            return View(slideDAO.ListAll());
        }

        // GET: Admin/Slide/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = slideDAO.GetByID(id);
            if (slide == null){
                return HttpNotFound();
            }
            return View(slide);
        }

        // GET: Admin/Slide/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slide/Create
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slide"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Image,DisplayOrder,Link,Description,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Status")] Slide slide)
        {
            if (ModelState.IsValid && slideDAO.Create(slide)){
                return RedirectToAction("Index");
            }

            return View(slide);
        }

        // GET: Admin/Slide/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = slideDAO.GetByID(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: Admin/Slide/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slide"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Image,DisplayOrder,Link,Description,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Status")] Slide slide)
        {
            if (ModelState.IsValid && slideDAO.Edit(slide)){ 
                return RedirectToAction("Index");
            }
            return View(slide);
        }

        // GET: Admin/Slide/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = slideDAO.GetByID(id);
            if (slide == null){
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: Admin/Slide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            slideDAO.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
