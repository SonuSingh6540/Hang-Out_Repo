using Entity;
using System;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Newtonsoft.Json;
using Utility;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            if (TempData["forgetPassword"] != null)
            {
                ViewBag.VerificationMessage = TempData["forgetPassword"].ToString();
            }
            var objENContest = new enContest() { GetByDate = true };
            var objBLContest = new blContest(objENContest);
            try
            {
                objENContest = objBLContest.ReadAll().FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            ViewBag.Contest = objENContest;
            return View();
        }

        [HttpPost]
        public ActionResult Login(enUser enUser_)
        {
            var objBLUser = new blUser(enUser_);
            try
            {
                objBLUser.Read();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Account.Login() Error while Read() User  Exception:-" + ex.ToString());
            }

            if (enUser_.ID == 0)
            {
                ViewBag.Exception = true;
                Log.Info("Couldn't find user with EmailID - " + enUser_.E_Mail + "and Password - " + enUser_.Password, false);
                TempData["forgetPassword"] = "User name or password is wrong";
                return RedirectToAction("login", "account");
            }
            else if (enUser_.Verified == false)
            {
                TempData["forgetPassword"] = "Your account is not verified. Please verify your account";
                return RedirectToAction("login", "account");
            }

            #region ContestStatus
            var objENContestStatus = new enContestStatus() { ContestID = enUser_.ContestID, UserID = enUser_.ID };
            var objBLContestStatus = new blContestStatus(objENContestStatus);
            objBLContestStatus.Read();
            if (objENContestStatus.ID > 0)
            {
                objENContestStatus.Status = enUser_.Status;
                objBLContestStatus.Update();
            }
            else
            {
                if (enUser_.Status == true)
                {
                    objENContestStatus.Status = enUser_.Status;
                    objBLContestStatus.Create();
                }
            }
            #endregion

            Session["User_ID"] = enUser_.ID;
            HttpCookie loginCookie = new HttpCookie("UILoginCookie");
            string Key = ConfigurationManager.AppSettings["EncryptKey"];
            var Password = Helper.EncryptString(enUser_.Password, Key);
            var cookieDetail = new enCookieDetail { E_mail = enUser_.E_Mail, Password = Password, UserID = enUser_.ID };
            loginCookie.Value = JsonConvert.SerializeObject(cookieDetail);
            loginCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(loginCookie);
            return RedirectToAction("About", "Content");
        }

        [HttpPost]
        public ActionResult Registration(enUser enUser_)
        {
            var objENUser = new enUser();
            enUser_.Reference_Code = Helper.GetRandomAlphaNumericPassword();
            enUser_.VerificationCode = Helper.GetRandomAlphaNumericPassword();

            var objBLUser = new blUser(enUser_);
            try
            {
                objBLUser.Create();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Account.Login() Error while Create() User  Exception:-" + ex.ToString());
                RedirectToAction("error", "misc");
            }

            if (enUser_.Sponsor_ID != null)
            {
                objENUser = new enUser() { Reference_Code = enUser_.Sponsor_ID };
                objBLUser = new blUser(objENUser);
                try
                {
                    objBLUser.Read();
                }
                catch (Exception ex)
                {
                    Log.Error("Hangout.UI.Account.Login() Error while Read() User  Exception:-" + ex.ToString());
                    RedirectToAction("error", "misc");
                }

                if (objENUser.ID > 0)
                {
                    var Point = (int)RewardPoints.OTHER_MEMBER;
                    if (objENUser.Country == (int)CountryCode.India)
                    {
                        Point = (int)RewardPoints.IN_MEMBER;
                    }
                    var objENReward = new enReward() { Point = Point, Type = (int)RewardType.MEMBER, User_ID = objENUser.ID };
                    var objBLReward = new blReward(objENReward);
                    try
                    {
                        objBLReward.Create();
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Hangout.UI.Account.Login() Error while Read() User  Exception:-" + ex.ToString());
                        RedirectToAction("error", "misc");
                    }

                    #region ContestStatus
                    var objENContestStatus = new enContestStatus() { ContestID = enUser_.ContestID, UserID = enUser_.ID, Status = enUser_.Status };
                    var objBLContestStatus = new blContestStatus(objENContestStatus);
                    objBLContestStatus.Create();
                    #endregion
                }
            }

            //Shoot Mail to verify User
            bool status = Helper.SendVerificationCodeToMail(enUser_.E_Mail, enUser_.VerificationCode);
            if (!status)
            {
                Log.Error("Hangout.UI.Account.Login() Error while Read() User");
                TempData["forgetPassword"] = "Invalid Email ID!";
                return RedirectToAction("login", "user");
            }

            objENUser = new enUser() { Reference_Code = enUser_.Reference_Code };
            objBLUser = new blUser(objENUser);
            try
            {
                objBLUser.Read();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Account.Login() Error while Read() User  Exception:-" + ex.ToString());
                return RedirectToAction("error", "misc");
            }
            TempData["forgetPassword"] = "Verification link send to your registered E_mail ID.";
            return RedirectToAction("login", "account");
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["UILoginCookie"] != null)
            {
                Request.Cookies["UILoginCookie"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(Request.Cookies["UILoginCookie"]);
            }

            return RedirectToAction("Login");
        }

        public JsonResult CheckAvailableMail(string mail_)
        {
            var objENUser = new enUser() { E_Mail = mail_ };
            var objBLUser = new blUser(objENUser);
            try
            {
                objBLUser.Read();
            }
            catch (Exception ex)
            {
                Log.Error("Project1.UI.AccountController.ChechkAvailableUser()  Error while Read() User  Exception:" + ex.ToString());
            }

            if (objENUser.ID <= 0)
            {
                return Json("f");
            }
            else
            {
                return Json("s");
            }
        }

        public ActionResult VerifyUser(string str)
        {
            var objENUser = new enUser() { VerificationCode = str };
            var objBLUser = new blUser(objENUser);
            try
            {
                objBLUser.Read();
            }
            catch (Exception ex)
            {
                Log.Error("UI.AccountController.VerifyCode.Error while Read() User Exception: " + ex.ToString());
            }

            if (objENUser.ID > 0)
            {
                try
                {
                    if (objENUser.Verified == false)
                    {
                        objENUser.Verified = true;
                        objBLUser.Update();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("UI.AccountController.VerifyCode(). Error while Update User  Exception:" + ex.ToString());
                    RedirectToAction("error", "misc");
                }
            }
            else
            {
                TempData["forgetPassword"] = "Invalid Verification Code!";
                return RedirectToAction("login", "account");
            }

            TempData["forgetPassword"] = "Congratulations! You have successfully verified your account";
            return RedirectToAction("login", "account");
        }

    }
}