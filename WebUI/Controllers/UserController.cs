using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.DAO;
using Domain.EF;
using WebUI.Common;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {

        private UserDAO userDAO = new UserDAO();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string name, string address, string email, string phone, string username, string password, string confirmpassword) {
            if ( !ModelState.IsValid || password != confirmpassword ) {
                ModelState.AddModelError(null, " Thông tin đăng nhập không đúng!");
            }
            else if (!userDAO.CheckRegister(username, email)) {
                ModelState.AddModelError(null, " Username hoặc Email đã tồn tại!");
            }  else {
                User user = new User();
                user.Name = name;
                user.Username = username;
                user.Password = Encryptor.MD5Hash(password);
                user.Phone = phone;
                user.Status = false;
                user.CreatedDate = DateTime.Now;
                user.Address = address;
                user.Email = email;

                userDAO.Insert(user);
                return RedirectToAction("RegisterSuccess", "User");
            }
            return null;
        }

        public ActionResult RegisterSuccess() {
            return View();
        }

        [HttpGet]
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password) {
            var checkLogin = userDAO.Login(username, Encryptor.MD5Hash(password));
            if (checkLogin) {
                var user = userDAO.GetByUername(username);
                // Lấy User trong DAO gán vào Session
                var userSession = new UserLogin();
                userSession.Username = user.Username;
                userSession.UserID = user.ID;
                userSession.Status = user.Status.Value;

                // Thêm User vào Session
                Session.Add(CommonConstant.USER_SESSION, userSession);
                return RedirectToAction("Index", "Home");


            }
            return View();
        }


    }
}