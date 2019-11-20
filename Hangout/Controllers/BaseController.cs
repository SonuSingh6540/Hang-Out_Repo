using System.Web.Mvc;
using Newtonsoft.Json;
using Entity;

namespace Hangout.Controllers
{
    public class BaseController : Controller
    {
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