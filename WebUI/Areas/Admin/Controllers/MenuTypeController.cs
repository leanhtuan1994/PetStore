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
    public class MenuTypeController : BaseController
    {
        private PetStoreDbContext db = new PetStoreDbContext();
        private MenuTypeDAO menuTypeDAO = new MenuTypeDAO();

        // GET: Admin/MenuType
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(menuTypeDAO.ListAll());
        }

        // GET: Admin/MenuType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MenuType/Create
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuType"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] MenuType menuType)
        {
            if (ModelState.IsValid && menuTypeDAO.Create(menuType) ){
                return RedirectToAction("Index");
            }

            return View(menuType);
        }

        // GET: Admin/MenuType/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuType menuType = menuTypeDAO.GetByID(id);
            if (menuType == null) {
                return HttpNotFound();
            }
            return View(menuType);
        }

        // POST: Admin/MenuType/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuType"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] MenuType menuType)
        {
            if (ModelState.IsValid && menuTypeDAO.Edit(menuType)) {              
                return RedirectToAction("Index");
            }
            return View(menuType);
        }

        // GET: Admin/MenuType/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(long? id)
        {
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuType menuType = menuTypeDAO.GetByID(id);
            if (menuType == null)  {
                return HttpNotFound();
            }
            return View(menuType);
        }

        // POST: Admin/MenuType/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            menuTypeDAO.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
