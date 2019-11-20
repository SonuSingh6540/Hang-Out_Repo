using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Entity;
using BusinessLogicLayer;
using System.IO;
using Utility;

namespace Hangout.Controllers
{
    public class AdvertisementController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(enAdvertisement enAdvertisement_)
        {
            //Reward Section
            if (enAdvertisement_.AdvertisementImage != null)
            {
                if (enAdvertisement_.Reference_Code != null)
                {
                    var objENUser = new enUser() { Reference_Code = enAdvertisement_.Reference_Code };
                    var objBLUser = new blUser(objENUser);
                    try
                    {
                        objBLUser.Read();
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("error", "misc");
                    }

                    if (objENUser.ID > 0)
                    {
                        var objENReward = new enReward();
                        objENReward.User_ID = objENUser.ID;
                        objENReward.Point = (int)RewardPoints.ADVERTISEMENT;
                        objENReward.Type = (int)RewardType.ADVERTISEMENT;
                        var objBLReward = new blReward(objENReward);
                        try
                        {
                            objBLReward.Create();
                        }
                        catch (Exception ex)
                        {
                          return  RedirectToAction("error", "misc");
                        }

                        var objENPayment = new enPayment();
                        objENPayment.Name = objENUser.Name;
                        objENPayment.E_Mail = objENUser.E_Mail;
                        objENPayment.Reference_Code = objENUser.Reference_Code;
                        objENPayment.Amount = enAdvertisement_.Amount;
                        var objBLPayment = new blPayment(objENPayment);
                        try
                        {
                            objBLPayment.Create();
                        }
                        catch (Exception ex)
                        {
                           return RedirectToAction("error", "misc");
                        }
                    }
                }

                enAdvertisement_.Image_Name = Path.GetFileName(enAdvertisement_.AdvertisementImage.FileName);
                enAdvertisement_.Image_Name = Helper.GetRandomAlphaNumericSMSToken() + "-" + enAdvertisement_.Image_Name;
                var objBLAdvertisement = new blAdvertisement(enAdvertisement_);
                try
                {
                    string extension = Path.GetExtension(enAdvertisement_.AdvertisementImage.FileName);
                    var path = Path.Combine(Server.MapPath(Helper.AdvertisementImagePath()) + enAdvertisement_.Image_Name);
                    bool exist = Directory.Exists(Server.MapPath(Helper.AdvertisementImagePath()));
                    if (!exist)
                        Directory.CreateDirectory(Server.MapPath(Helper.AdvertisementImagePath()));
                    enAdvertisement_.AdvertisementImage.SaveAs(path);
                }
                catch (Exception ex)
                {
                    return RedirectToAction("error", "misc");
                }
                try
                {
                    objBLAdvertisement.Create();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("error", "misc");
                }
            }
            else
            {
                return RedirectToAction("error", "misc");
            }

            return RedirectToAction("list");
        }

        public ActionResult List(enAdvertisement enAdvertisement_)
        {
            var objENAdvertisement = new enAdvertisement();
            var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
            List<enAdvertisement> listOfAdvertisements = new List<enAdvertisement>();
            try
            {
                listOfAdvertisements = objBLAdvertisement.ReadAll();
            }
            catch
            {

            }

            return View(listOfAdvertisements);
        }

        public ActionResult Update(int id)
        {
            var objENAdvertisement = new enAdvertisement() { ID = id };
            var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
            List<enAdvertisement> listOfAdvertisements = new List<enAdvertisement>();
            try
            {
                objBLAdvertisement.Read();
            }
            catch
            {
                RedirectToAction("error", "misc");
            }
            objENAdvertisement.Date_To = objENAdvertisement.Date_To.Date;
            return View("index", objENAdvertisement);
        }

        [HttpPost]
        public ActionResult Update(int id, enAdvertisement enAdvertisement_)
        {
            var objENAdvertisement = new enAdvertisement() { ID = id };
            var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
            List<enAdvertisement> listOfAdvertisements = new List<enAdvertisement>();
            if (enAdvertisement_.AdvertisementImage != null)
            {
                enAdvertisement_.Image_Name = Path.GetFileName(enAdvertisement_.AdvertisementImage.FileName);
                enAdvertisement_.Image_Name = Helper.GetRandomAlphaNumericSMSToken() + "-" + enAdvertisement_.Image_Name;
                try
                {
                    string extension = Path.GetExtension(enAdvertisement_.AdvertisementImage.FileName);
                    var path = Path.Combine(Server.MapPath(Helper.AdvertisementImagePath()) + enAdvertisement_.Image_Name);
                    bool exist = Directory.Exists(Server.MapPath(Helper.AdvertisementImagePath()));
                    if (!exist)
                        Directory.CreateDirectory(Server.MapPath(Helper.AdvertisementImagePath()));
                    enAdvertisement_.AdvertisementImage.SaveAs(path);
                }
                catch (Exception ex)
                {
                    return RedirectToAction("error", "misc");
                }
                try
                {
                    objBLAdvertisement.Read();
                }
                catch
                {
                    RedirectToAction("error", "misc");
                }

                enAdvertisement_.InsertedOn = objENAdvertisement.InsertedOn;
                objBLAdvertisement = new blAdvertisement(enAdvertisement_);
                try
                {
                    objBLAdvertisement.Update();
                }
                catch
                {
                    RedirectToAction("error", "misc");
                }
            }
            else
            {
                return RedirectToAction("error", "misc");
            }

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var objENAdvertisement = new enAdvertisement() { ID = id };
            var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
            try
            {
                objBLAdvertisement.Delete();
            }
            catch
            {
                return RedirectToAction("error", "misc");
            }
            return RedirectToAction("list");
        }

        public ActionResult Payment()
        {
            var objENPayment = new enPayment();
            var objBLPayment = new blPayment(objENPayment);
            List<enPayment> listOfPayments = new List<enPayment>();
            try
            {
                listOfPayments = objBLPayment.ReadAll();
            }
            catch (Exception ex)
            {
                return RedirectToAction("error", "misc");
            }
            return View(listOfPayments);
        }
    }
}