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
    public class MenuController : BaseController
    {
        private MenuDAO menuDAO = new MenuDAO();
        private MenuTypeDAO menuTypeDAO = new MenuTypeDAO();

        // GET: Admin/Menu
        public ActionResult Index()
        {
            return View(menuDAO.ListAll());
        }

        // GET: Admin/Menu/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(long? id)
        {
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = menuDAO.GetByID(id);
            if (menu == null){
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Admin/Menu/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        // POST: Admin/Menu/Create
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Text,Link,DisplayOrder,Target,Status,TypeID")] Menu menu)
        {
            if (ModelState.IsValid && menuDAO.Create(menu)) {
                return RedirectToAction("Index");
            }

            SetViewBag(menu.TypeID);
            return View(menu);
        }

        // GET: Admin/Menu/Edit/5
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
            Menu menu = menuDAO.GetByID(id);
            if (menu == null){
                return HttpNotFound();
            }
            SetViewBag(menu.TypeID);
            return View(menu);
        }

        // POST: Admin/Menu/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Text,Link,DisplayOrder,Target,Status,TypeID")] Menu menu)
        {
            if (ModelState.IsValid && menuDAO.Edit(menu)){
                return RedirectToAction("Index");
            }
            SetViewBag(menu.TypeID);
            return View(menu);
        }

        // GET: Admin/Menu/Delete/5
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
            Menu menu = menuDAO.GetByID(id);
            if (menu == null){
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Admin/Menu/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            menuDAO.Delete(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeID"></param>
        void SetViewBag(long? typeID = null) {
            ViewBag.TypeID = new SelectList(menuTypeDAO.ListAll(), "ID", "Name", typeID);
        }


    }
}
