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

namespace WebUI.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerDAO customerDAO = new CustomerDAO();

        // GET: Admin/Customer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            return View(customerDAO.ListAllPaging(page, pageSize));
        }

        // GET: Admin/Customer/Details/5
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
            Customer customer = customerDAO.GetByID(id);
            if (customer == null){
                return HttpNotFound();
            }
            return View(customer);
        }

        

        // GET: Admin/Customer/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = customerDAO.GetByID(id);
            if (customer == null){
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Customer/Edit/5
       /// <summary>
       /// 
       /// </summary>
       /// <param name="customer"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,Email,Phone,CreatedDate,ShipName,ShipAddress,ShipPhone")] Customer customer)
        {
            if (ModelState.IsValid && customerDAO.Edit(customer)){
              
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Admin/Customer/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = customerDAO.GetByID(id);
            if (customer == null){
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            customerDAO.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
