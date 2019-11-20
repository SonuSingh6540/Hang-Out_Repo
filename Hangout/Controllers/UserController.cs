using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Entity;
using BusinessLogicLayer;

namespace Hangout.Controllers
{
    public class UserController : Controller
    {
        public ActionResult List()
        {
            var objENUser = new enUser();
            var objBLUser = new blUser(objENUser);
            List<enUser> listOfUsers = new List<enUser>();
            try
            {
                listOfUsers = objBLUser.ReadAll();
            }
            catch (Exception ex)
            {
                
            }
            return View(listOfUsers);
        }

        public ActionResult getMember(string sponsorID)
        {
            var objENUser = new enUser() { Sponsor_ID = sponsorID};
            var objBLUser = new blUser(objENUser);
            List<enUser> listOfUsers = new List<enUser>();
            try
            {
                listOfUsers = objBLUser.ReadAll();
            }
            catch (Exception ex)
            {
                return Json("Failure",JsonRequestBehavior.AllowGet);
            }
            return Json(listOfUsers, JsonRequestBehavior.AllowGet);
        }
    }
}