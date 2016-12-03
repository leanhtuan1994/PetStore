using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Areas.Admin.Models;
using Domain.DAO;
using WebUI.Common;

namespace WebUI.Areas.Admin.Controllers
{
    public class LoginController : Controller {
        private UserDAO userDAO = new UserDAO();

        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model) {
            // Gọi UserDAO để kiểm tra login
            var checkLogin = userDAO.Login(model.Username, Encryptor.MD5Hash(model.Password));
            if(checkLogin) {
                var user = userDAO.GetByUername(model.Username);

                // Lấy User trong DAO gán vào Session
                var userSession = new UserLogin();
                userSession.Username = user.Username;
                userSession.UserID = user.ID;
                userSession.RememberMe = model.RememberMe;

                // Thêm User vào Session
                Session.Add(CommonConstant.USER_SESSION, userSession);
                return RedirectToAction("Index", "Home");

            }

            return View(); 
        }

    }
}