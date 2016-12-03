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
using WebUI.Common;

namespace WebUI.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // Tạo Ob userDAO từ USERDAO
        private UserDAO userDAO = new UserDAO();

        // GET: Admin/User
        /// <summary>
        /// Lấy list danh sách user kèm theo page, pageSize
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            return View(userDAO.ListAllPaging(page, pageSize));
        }

        // GET: Admin/User/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userDAO.GetByID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,Password,Name,Address,Email,Phone,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Status")] User user)
        {
            if (ModelState.IsValid) {
                user.Password = Encryptor.MD5Hash(user.Password);
                userDAO.Insert(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)   {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userDAO.GetByID(id);
            if (user == null)    {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/User/Edit/5
       /// <summary>
       /// 
       /// </summary>
       /// <param name="user"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,Password,Name,Address,Email,Phone,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Status")] User user)
        {
            if (ModelState.IsValid)  {
                user.Password = Encryptor.MD5Hash(user.Password);
                userDAO.Edit(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/User/Delete/5
        /// <summary>
        /// Lấy id truyền vào View Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(long? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userDAO.GetByID(id);
            if (user == null) {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/User/Delete/5
        /// <summary>
        /// Xóa User nếu nhận comfirmed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var result = userDAO.Delete(id);
            if (result) {
                return RedirectToAction("Index");
            }
            return View();  
        }

        


    }
}
