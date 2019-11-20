using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BusinessLogicLayer;
using Utility;

namespace Hangout.Controllers
{
    public class QueryController : Controller
    {
        public ActionResult Advertise()
        {
            var objENQuery = new enQuery() { Type = (int)Query_Type.ADVERTISE };
            var objBLQuery = new blQuery(objENQuery);
            List<enQuery> listOfQueries = new List<enQuery>();
            try
            {
                listOfQueries = objBLQuery.ReadAll();
            }
            catch (Exception ex)
            {
            }
            return View(listOfQueries);
        }
        public ActionResult ContactUs()
        {
            var objENQuery = new enQuery() { Type = (int)Query_Type.CONTACTUS };
            var objBLQuery = new blQuery(objENQuery);
            List<enQuery> listOfQueries = new List<enQuery>();
            try
            {
                listOfQueries = objBLQuery.ReadAll();
            }
            catch (Exception ex)
            {
            }
            return View(listOfQueries);
        }
        public ActionResult TopicAndIdea()
        {
            var objENQuery = new enQuery() { Type = (int)Query_Type.IDEA };
            var objBLQuery = new blQuery(objENQuery);
            List<enQuery> listOfQueries = new List<enQuery>();
            try
            {
                listOfQueries = objBLQuery.ReadAll();
            }
            catch (Exception ex)
            {
            }
            return View(listOfQueries);
        }
        public JsonResult QueryConfirmation(int qID, int t_type, int confType)
        {
            var Point_ = (int)RewardPoints.TOPIC;
            var Type_ = (int)RewardType.TOPIC;
            if (t_type == 1)
            {
                Point_ = (int)RewardPoints.IDEA;
                Type_ = (int)RewardType.IDEA;
            }

            if (confType == 1)
            {
                var objENReward = new enReward() { User_ID = qID, Point = Point_, Type = Type_ };
                var objBLReward = new blReward(objENReward);
                try
                {
                    objBLReward.Create();
                }
                catch (Exception ex)
                {
                    return Json("failure", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var objENQuery = new enQuery() { ID = qID};
                var objBLQuery = new blQuery(objENQuery);
                try
                {
                    objBLQuery.Delete();
                }
                catch (Exception ex)
                {
                    return Json("failure", JsonRequestBehavior.AllowGet);
                }
            }

            return Json("success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Gallery(int advertisementID , int userID)
        {
            var objENAdvertisementImage = new enAdvertisementImage() { Advertisement_ID = advertisementID};
            var objBLAdvertisementImage = new blAdvertisementImage(objENAdvertisementImage);
            List<enAdvertisementImage> listOfAdvertisementImages = new List<enAdvertisementImage>();
            try
            {
                listOfAdvertisementImages = objBLAdvertisementImage.ReadAll();
            }
            catch (Exception ex)
            {
                RedirectToAction("error","misc");
            }
            ViewBag.UserID = userID;
            return View(listOfAdvertisementImages);
        }
    }
}