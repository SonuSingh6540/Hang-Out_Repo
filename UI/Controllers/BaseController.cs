using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;

namespace UI.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public enCookieDetail CookieDetail
        {
            get
            {
                if (Request.Cookies["UILoginCookie"] == null)
                    return null;
                return (enCookieDetail)JsonConvert.DeserializeObject(Request.Cookies["UILoginCookie"].Value, typeof(enCookieDetail));
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Request.Cookies["UILoginCookie"] == null && (filterContext.Controller.ControllerContext.RouteData.Values["action"].ToString().ToLower() != "login"
                || filterContext.Controller.ControllerContext.RouteData.Values["controller"].ToString().ToLower() != "account"))
            {
                filterContext.Result = RedirectToAction("login", "account");
                return;
            }

        }
    }
}