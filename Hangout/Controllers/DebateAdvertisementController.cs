using BusinessLogicLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using Utility;

namespace Hangout.Controllers
{
    public class DebateAdvertisementController : Controller
    {
        // GET: DebateAdvertisement
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(enDebateAdvertisement enDebateAdvertisement_)
        {
            var objBLDebateAdvertisement = new blDebateAdvertisement(enDebateAdvertisement_);
            try
            {
                objBLDebateAdvertisement.Create();
            }
            catch (Exception ex)
            {
                return RedirectToAction("error", "misc");
            }
            return RedirectToAction("list");
        }

        public ActionResult List()
        {
            var objENDebateAdvertisement = new enDebateAdvertisement();
            var objBLDebateAdvertisement = new blDebateAdvertisement(objENDebateAdvertisement);
            List<enDebateAdvertisement> listOfDebateAdvertisements = new List<enDebateAdvertisement>();
            try
            {
                listOfDebateAdvertisements = objBLDebateAdvertisement.ReadAll();
            }
            catch(Exception ex)
            {
                return RedirectToAction("error", "misc");
            }

            return View(listOfDebateAdvertisements);
        }

        public ActionResult Update(int id)
        {
            var objENDebateAdvertisement = new enDebateAdvertisement() { ID = id };
            var objBLDebateAdvertisement = new blDebateAdvertisement(objENDebateAdvertisement);
            List<enDebateAdvertisement> listOfDebateAdvertisements = new List<enDebateAdvertisement>();
            try
            {
                objBLDebateAdvertisement.Read();
            }
            catch
            {
                RedirectToAction("error", "misc");
            }
            return View("index", objENDebateAdvertisement);
        }

        [HttpPost]
        public ActionResult Update(int id, enDebateAdvertisement enDebateAdvertisement_)
        {
            var objENDebateAdvertisement = new enDebateAdvertisement() { ID = id };
            var objBLDebateAdvertisement = new blDebateAdvertisement(objENDebateAdvertisement);

            enDebateAdvertisement_.CreatedOn = objENDebateAdvertisement.CreatedOn;
            objBLDebateAdvertisement = new blDebateAdvertisement(enDebateAdvertisement_);
            try
            {
                objBLDebateAdvertisement.Update();
            }
            catch
            {
                RedirectToAction("error", "misc");
            }

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var objENDebateAdvertisement = new enDebateAdvertisement() { ID = id };
            var objBLDebateAdvertisement = new blDebateAdvertisement(objENDebateAdvertisement);
            try
            {
                objBLDebateAdvertisement.Delete();
            }
            catch
            {
                return RedirectToAction("error", "misc");
            }
            return RedirectToAction("list");
        }

        public ActionResult UploadImage(int id)
        {
            var objENDebateAdvertisementImage = new enDebateAdvertisementImage() { FKDebateAdvertisementId = id };
            var objBLDebateAdvertisementImage = new blDebateAdvertisementImage(objENDebateAdvertisementImage);
            List<enDebateAdvertisementImage> listOfDebateAdvertisementLists = new List<enDebateAdvertisementImage>();
            try
            {
                listOfDebateAdvertisementLists = objBLDebateAdvertisementImage.ReadAll();
            }
            catch (Exception ex)
            {
                return RedirectToAction("error", "misc");
            }

            List<enDebateAdvertisementImage> currentDebateAdvertisementLists = new List<enDebateAdvertisementImage>();
            for (var i = 0; i < 10; i++)
            {
                if (listOfDebateAdvertisementLists.Count > i)
                    currentDebateAdvertisementLists.Add(listOfDebateAdvertisementLists[i]);
                else
                {
                    currentDebateAdvertisementLists.Add(new enDebateAdvertisementImage() { FKDebateAdvertisementId = id });
                }
            }
            return View(currentDebateAdvertisementLists);
        }

        [HttpPost]
        public ActionResult UploadImage(List<enDebateAdvertisementImage> listOfDebateAdvertisementImages)
        {
            foreach (var debateAdvertisementImage in listOfDebateAdvertisementImages)
            {
                var objBlDebateAdvertisementImage = new blDebateAdvertisementImage(debateAdvertisementImage);

                if (debateAdvertisementImage.ID > 0)
                {
                    try
                    {
                        objBlDebateAdvertisementImage.Update();
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("error", "misc");
                    }
                }
                else if (debateAdvertisementImage.files[0] != null && debateAdvertisementImage.Url != null)
                {

                    try
                    {
                        var random = Helper.GetRandomAlphaNumericSMSToken();
                        var path = Path.Combine(Server.MapPath(Helper.DebateAdvertisementImagePath(listOfDebateAdvertisementImages[0].FKDebateAdvertisementId))+random + "-" + debateAdvertisementImage.files[0].FileName);
                        debateAdvertisementImage.ImagePath = random + "-" + debateAdvertisementImage.files[0].FileName;
                        objBlDebateAdvertisementImage.Create();

                        bool exist = Directory.Exists(Server.MapPath(Helper.DebateAdvertisementImagePath(listOfDebateAdvertisementImages[0].FKDebateAdvertisementId)));
                        if (!exist)
                            Directory.CreateDirectory(Server.MapPath(Helper.DebateAdvertisementImagePath(listOfDebateAdvertisementImages[0].FKDebateAdvertisementId)));
                        debateAdvertisementImage.files[0].SaveAs(path);
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("error", "misc");
                    }
                }
            }

            return RedirectToAction("UploadImage", new { id = listOfDebateAdvertisementImages[0].FKDebateAdvertisementId });
        }

        public ActionResult DeleteDebateAdvertisementImage(int id)
        {
            var objENDebateAdvertisementImage = new enDebateAdvertisementImage() { ID = id };
            var objBLDebateAdvertisementImage = new blDebateAdvertisementImage(objENDebateAdvertisementImage);
            var debateAdvertisementId = 0;
            try
            {
                objBLDebateAdvertisementImage.Read();
                debateAdvertisementId = objENDebateAdvertisementImage.FKDebateAdvertisementId;

                objBLDebateAdvertisementImage.Delete();
            }
            catch (Exception ex)
            {
                return RedirectToAction("error", "misc");
            }
            return RedirectToAction("UploadImage",new { id = debateAdvertisementId });
        }
    }
}