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
    public class OrdersController : BaseController {
        private OrdersDAO ordersDAO = new OrdersDAO();
        private CustomerDAO customerDAO = new CustomerDAO();

        // GET: Admin/Orders
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult Index(int page = 1, int pageSize = 10)
        {           
            return View(ordersDAO.ListAllPaging(page, pageSize));
        }

        // GET: Admin/Orders/Details/5
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
            Orders orders = ordersDAO.GetByID(id);
            if (orders == null){
                return HttpNotFound();
            }
            return View(orders);
        }


       
        // GET: Admin/Orders/Edit/5
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
            Orders orders = ordersDAO.GetByID(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(customerDAO.ListAll(), "ID", "Name", orders.CustomerID);
            return View(orders);
        }

        // POST: Admin/Orders/Edit/5
       /// <summary>
       /// 
       /// </summary>
       /// <param name="orders"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerID,DisplayOrder,Total,OrderStatus,OrderDate,ShipDate,ShipStatus")] Orders orders)
        {
            if (ModelState.IsValid && ordersDAO.Edit(orders)) {
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(customerDAO.ListAll(), "ID", "Name", orders.CustomerID);
            return View(orders);
        }

        // GET: Admin/Orders/Delete/5
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
            Orders orders = ordersDAO.GetByID(id);
            if (orders == null) {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Admin/Orders/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ordersDAO.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
