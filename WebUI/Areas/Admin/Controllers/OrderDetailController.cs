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
    public class OrderDetailController : BaseController
    {
        private OrderDetailDAO orderDetailDAO = new OrderDetailDAO();
        private ProductDAO productDAO = new ProductDAO();
        private OrdersDAO ordersDAO = new OrdersDAO();

        // GET: Admin/OrderDetail
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            return View(orderDetailDAO.ListAllPaging(page, pageSize));
        }

        // GET: Admin/OrderDetail/Details/5
        public ActionResult Details(long? orderID, long? productID)
        {
            if (orderID == null || productID == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = orderDetailDAO.GetByID(orderID, productID);
            if (orderDetail == null){
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: Admin/OrderDetail/Edit/5
        public ActionResult Edit(long? orderID, long? productID)
        {
            if (orderID == null || productID == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = orderDetailDAO.GetByID(orderID, productID);
            if (orderDetail == null) {
                return HttpNotFound();
            }

            SetViewBag(orderDetail.OrderID, orderDetail.ProductID);
            return View(orderDetail);
        }

        // POST: Admin/OrderDetail/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,ProductID,DisplayOrder,Price,Quantity,Total")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid && orderDetailDAO.Edit(orderDetail)) {
                return RedirectToAction("Index");
            }

            SetViewBag(orderDetail.OrderID, orderDetail.ProductID);
            return View(orderDetail);
        }

        // GET: Admin/OrderDetail/Delete/5
        public ActionResult Delete(long? orderID, long? productID )
        {
            if (orderID == null || productID == null ){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = orderDetailDAO.GetByID(orderID, productID);
            if (orderDetail == null){
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: Admin/OrderDetail/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long orderID, long productID )
        {
            orderDetailDAO.Delete(orderID, productID);
            return RedirectToAction("Index");
        }

        void SetViewBag(long? orderID = null, long? productID = null) {
            ViewBag.OrderID = new SelectList(ordersDAO.ListAll(), "ID", "ID", orderID);
            ViewBag.ProductID = new SelectList(productDAO.ListAll(), "ID", "Name", productID);
        }
    }
}
