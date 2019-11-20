using System;
using System.Web.Mvc;
using System.IO;
using System.Collections.Generic;
using Entity;
using BusinessLogicLayer;
using Utility;
using BusinessLogicLayer.CompositeBusinessLogic;

namespace UI.Controllers
{
    public class QueryController : BaseController
    {
        public ActionResult Advertise()
        {
            ViewBag.Msg = TempData["ErrorMessage"] as string; 
            return View();
        }

        [HttpPost]
        public ActionResult Advertise(enQuery enQuery_)
        {
            if (enQuery_.files != null)
            {
                enQuery_.Type = (int)Query_Type.ADVERTISE;
                enQuery_.User_ID = CookieDetail.UserID;
                enQuery_.ListOfAdvertisementImages = new List<enAdvertisementImage>();
                foreach (var image in enQuery_.files)
                {
                    enQuery_.File_Name = Path.GetFileName(image.FileName);
                    enQuery_.File_Name = Helper.GetRandomAlphaNumericSMSToken() + "-" + enQuery_.File_Name;
                    var objENQuery = new blQuery(enQuery_);
                    try
                    {
                        var path = Path.Combine(Server.MapPath(Helper.UserAdvertisementImagePath((int)Session["User_ID"]) + enQuery_.File_Name));
                        bool exist = Directory.Exists(Server.MapPath(Helper.UserAdvertisementImagePath((int)Session["User_ID"])));
                        if (!exist)
                            Directory.CreateDirectory(Server.MapPath(Helper.UserAdvertisementImagePath((int)Session["User_ID"])));
                        image.SaveAs(path);
                        enQuery_.ListOfAdvertisementImages.Add(new enAdvertisementImage { Name = enQuery_.File_Name });
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Hangout.UI.QueryController.Advertise() Error while Create() UserAdvertisementPath Exception: " + ex.ToString());
                    }
                }

                var objCBQuery = new cbQuery();
                try
                {
                    objCBQuery.createCompleteSection(enQuery_);
                }
                catch (Exception ex)
                {
                    Log.Error("Hangout.UI.QueryController.Advertise() Error while Create() Query  Exception:" + ex.ToString());
                }
                TempData["ErrorMessage"] = "Message is successfully submitted...";
                return RedirectToAction("advertise");
            }
            else
            {
                return RedirectToAction("error", "misc");
            }
        }

        public ActionResult ContactUs()
        {
            ViewBag.Msg = TempData["ErrorMessage"] as string;
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(enQuery enQuery_)
        {
            enQuery_.Type = (int)Query_Type.CONTACTUS;
            enQuery_.User_ID = CookieDetail.UserID;
            var objBLQuery = new blQuery(enQuery_);
            try
            {
                objBLQuery.Create();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.QueryController.ContactUs() Error while Create() Query Exception:-" + ex.ToString());
            }
            TempData["ErrorMessage"] = "Message is successfully submitted...";
            return RedirectToAction("contactus");
        }

        public ActionResult Profile()
        {
            ViewBag.Msg = TempData["ErrorMessage"] as string;
            ViewBag.UserID = CookieDetail.UserID;
            return View();
        }

        [HttpPost]
        public ActionResult Profile(enQuery enQuery_)
        {
            enQuery_.Type = (int)Query_Type.IDEA;
            enQuery_.User_ID = CookieDetail.UserID;
            var objBLQuery = new blQuery(enQuery_);
            try
            {
                objBLQuery.Create();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.QueryController.Profile() Error while Create() Query Exception:-" + ex.ToString());
            }
            TempData["ErrorMessage"] = "Message is successfully submitted...";
            return RedirectToAction("profile");
        }

        public JsonResult GetProfile(int userID)
        {
            var objENUser = new enUser() { ID = userID };
            var objBLUser = new blUser(objENUser);
            try
            {
                objBLUser.Read();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.QueryController.GetMember() Error while Read() User Excpetion:-" + ex.ToString());
                return Json("null", JsonRequestBehavior.AllowGet);
            }
            return Json(objENUser);
        }

        public JsonResult GetPoints(int userID)
        {
            var objENReward = new enReward() { User_ID = userID };
            var objBLReward = new blReward(objENReward);
            List<enReward> listOfRewards = new List<enReward>();
            try
            {
                listOfRewards = objBLReward.ReadAll();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.QueryController.GetMember() Error while ReadAll() Reward Excpetion:-" + ex.ToString());
                return Json("null", JsonRequestBehavior.AllowGet);
            }

            var objENRewardPoints = new RewardPoint();
            foreach (var item in listOfRewards)
            {
                if (item.Type == (int)RewardType.ADVERTISEMENT)
                {
                    objENRewardPoints.AdvertisePoint += item.Point;
                }
                else if (item.Type == (int)RewardType.IDEA)
                {
                    objENRewardPoints.IdeaPoint += item.Point;
                }
                else if (item.Type == (int)RewardType.MEMBER)
                {
                    objENRewardPoints.MemberPoint += item.Point;
                }
                else if (item.Type == (int)RewardType.TOPIC)
                {
                    objENRewardPoints.TopicPoint += item.Point;
                }
                else if (item.Type == (int)RewardType.WINNER)
                {
                    objENRewardPoints.WinnerPoint += item.Point;
                }
            }
            return Json(objENRewardPoints, JsonRequestBehavior.AllowGet);
        }

        private class RewardPoint
        {
            public int AdvertisePoint { get; set; }
            public int IdeaPoint { get; set; }
            public int MemberPoint { get; set; }
            public int TopicPoint { get; set; }
            public int WinnerPoint { get; set; }
        }
    }
}

