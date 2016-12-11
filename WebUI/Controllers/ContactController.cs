using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.DAO;


namespace WebUI.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ViewBag.ContactInfo = new ContactDAO().ListAll();
            return View();
        }

        public ActionResult Feedback(string name, string phone, string address, string email, string content ) {
            try {
                var feedDAO = new FeedbackDAO().Create(name, phone, address, email, content);
            }   catch {

            }
            return Redirect("/");
        }
    }
}