using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Common;
using System.Web.Routing;

namespace WebUI.Areas.Admin.Controllers {
    // Lớp Kiểm tra Session User đã đăng nhập hay chưa
    public class BaseController : Controller {
        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            // Lấy Session về và ép thành UserLogin 
            var userSession = (UserLogin)Session[CommonConstant.USER_SESSION];
            if (userSession == null || userSession.Status == false) {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new {
                    controller = "Login", action = "Index", Area = "Admin"
                }));
            }

            base.OnActionExecuting(filterContext);

        }
    }
}