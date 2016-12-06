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
    public class FeedbackController : BaseController
    {
        private FeedbackDAO feedbackDAO = new FeedbackDAO();

        // GET: Admin/Feedback
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            return View(feedbackDAO.ListAllPaging(page, pageSize));
        }

        // GET: Admin/Feedback/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = feedbackDAO.GetByID(id);
            if (feedback == null)   {
                return HttpNotFound();
            }
            return View(feedback);
        }    

        // GET: Admin/Feedback/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = feedbackDAO.GetByID(id);
            if (feedback == null) {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Admin/Feedback/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Phone,Email,Address,Content,CreatedDate,Status")] Feedback feedback)
        {
            if (ModelState.IsValid && feedbackDAO.Edit(feedback)){
                return RedirectToAction("Index");
            }
            return View(feedback);
        }

        // GET: Admin/Feedback/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = feedbackDAO.GetByID(id);
            if (feedback == null){
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Admin/Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            feedbackDAO.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
