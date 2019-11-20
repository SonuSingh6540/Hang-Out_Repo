using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BusinessLogicLayer;
using Utility;

namespace UI.Controllers
{
    public class ContentController : BaseController
    {
        public ActionResult About()
        {
            var objENContent = new enContent() { Type = (int)ContentType.About };
            var objBLContent = new blContent(objENContent);
            try
            {
                objBLContent.Read();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.About() Error while Read() Content Exception: " + ex.ToString());
            }

            //Advertisement Panel
            var objENAdvertisement = new enAdvertisement() { Content_ID = (int)ContentType.About };
            var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
            List<enAdvertisement> listOfAdvertisements = new List<enAdvertisement>();
            try
            {
                listOfAdvertisements = objBLAdvertisement.ReadAll();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.About() Error while Read() Advertisement  Exception:- " + ex.ToString());
            }

            List<enAdvertisement> leftAdvPanel = new List<enAdvertisement>();
            List<enAdvertisement> rightAdvPanel = new List<enAdvertisement>();
            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.LEFT))
            {
                if (item.Date_To.Date <= DateTime.Now.Date && item.Date_From.Date >= DateTime.Now.Date)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        leftAdvPanel.Add(item);
                    }
                }
            }

            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.RIGHT))
            {
                if (item.Date_To.Date <= DateTime.Now.Date && item.Date_From.Date >= DateTime.Now.Date)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        rightAdvPanel.Add(item);
                    }
                }
            }

            if (leftAdvPanel.Count > 0)
                ViewBag.LeftAdvPanel = leftAdvPanel.FirstOrDefault();
            if (rightAdvPanel.Count > 0)
                ViewBag.RightAdvPanel = rightAdvPanel.FirstOrDefault();

            return View(objENContent);
        }

        public ActionResult TermsAndConditions()
        {
            var objENContent = new enContent() { Type = (int)ContentType.TermAndCondition };
            var objBLContent = new blContent(objENContent);
            try
            {
                objBLContent.Read();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.TermsAndConditions() Error while Read() Content");
            }

            //Advertisement Panel
            var objENAdvertisement = new enAdvertisement() { Content_ID = (int)ContentType.TermAndCondition };
            var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
            List<enAdvertisement> listOfAdvertisements = new List<enAdvertisement>();
            try
            {
                listOfAdvertisements = objBLAdvertisement.ReadAll();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.About() Error while Read() Advertisement  Exception:- " + ex.ToString());
            }
            
            List<enAdvertisement> leftAdvPanel = new List<enAdvertisement>();
            List<enAdvertisement> rightAdvPanel = new List<enAdvertisement>();
            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.LEFT))
            {
                if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        leftAdvPanel.Add(item);
                    }
                }
            }

            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.RIGHT))
            {
                if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        rightAdvPanel.Add(item);
                    }
                }
            }

            if (leftAdvPanel.Count > 0)
                ViewBag.LeftAdvPanel = leftAdvPanel.FirstOrDefault();
            if (rightAdvPanel.Count > 0)
                ViewBag.RightAdvPanel = rightAdvPanel.FirstOrDefault();
            return View(objENContent);
        }

        public ActionResult Member()
        {
            var objENContent = new enContent() { Type = (int)ContentType.AddMember };
            var objBLContent = new blContent(objENContent);
            try
            {
                objBLContent.Read();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.Member() Error while Read() Content");
            }

            //Advertisement Panel
            var objENAdvertisement = new enAdvertisement() { Content_ID = (int)ContentType.AddMember };
            var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
            List<enAdvertisement> listOfAdvertisements = new List<enAdvertisement>();
            try
            {
                listOfAdvertisements = objBLAdvertisement.ReadAll();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.About() Error while Read() Advertisement  Exception:- " + ex.ToString());
            }

            List<enAdvertisement> leftAdvPanel = new List<enAdvertisement>();
            List<enAdvertisement> rightAdvPanel = new List<enAdvertisement>();
            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.LEFT))
            {
                if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        leftAdvPanel.Add(item);
                    }
                }
            }

            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.RIGHT))
            {
                if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        rightAdvPanel.Add(item);
                    }
                }
            }

            if (leftAdvPanel.Count > 0)
                ViewBag.LeftAdvPanel = leftAdvPanel.FirstOrDefault();
            if (rightAdvPanel.Count > 0)
                ViewBag.RightAdvPanel = rightAdvPanel.FirstOrDefault();
            return View(objENContent);
        }

        public ActionResult Advertisement()
        {
            var objENContent = new enContent() { Type = (int)ContentType.Advertisement };
            var objBLContent = new blContent(objENContent);
            try
            {
                objBLContent.Read();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.Advertisement() Error while Read() Content");
            }

            //Advertisement Panel
            var objENAdvertisement = new enAdvertisement() { Content_ID = (int)ContentType.Advertisement };
            var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
            List<enAdvertisement> listOfAdvertisements = new List<enAdvertisement>();
            try
            {
                listOfAdvertisements = objBLAdvertisement.ReadAll();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.About() Error while Read() Advertisement  Exception:- " + ex.ToString());
            }

            List<enAdvertisement> leftAdvPanel = new List<enAdvertisement>();
            List<enAdvertisement> rightAdvPanel = new List<enAdvertisement>();
            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.LEFT))
            {
                if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        leftAdvPanel.Add(item);
                    }
                }
            }

            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.RIGHT))
            {
                if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        rightAdvPanel.Add(item);
                    }
                }
            }

            if (leftAdvPanel.Count > 0)
                ViewBag.LeftAdvPanel = leftAdvPanel.FirstOrDefault();
            if (rightAdvPanel.Count > 0)
                ViewBag.RightAdvPanel = rightAdvPanel.FirstOrDefault();
            return View(objENContent);
        }

        //public ActionResult Blog()
        //{
        //    var objENContent = new enContent() { Type = (int)ContentType.Blog };
        //    var objBLContent = new blContent(objENContent);
        //    try
        //    {
        //        objBLContent.Read();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("Hangout.UI.Content.Blog() Error while Read() Content");
        //    }

        //    //Advertisement Panel
        //    var objENAdvertisement = new enAdvertisement() { Content_ID = (int)ContentType.Blog};
        //    var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
        //    List<enAdvertisement> listOfAdvertisements = new List<enAdvertisement>();
        //    try
        //    {
        //        listOfAdvertisements = objBLAdvertisement.ReadAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("Hangout.UI.Content.About() Error while Read() Advertisement  Exception:- " + ex.ToString());
        //    }

        //    List<enAdvertisement> leftAdvPanel = new List<enAdvertisement>();
        //    List<enAdvertisement> rightAdvPanel = new List<enAdvertisement>();
        //    foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.LEFT))
        //    {
        //        if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
        //        {
        //            if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
        //            {
        //                leftAdvPanel.Add(item);
        //            }
        //        }
        //    }

        //    foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.RIGHT))
        //    {
        //        if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
        //        {
        //            if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
        //            {
        //                rightAdvPanel.Add(item);
        //            }
        //        }
        //    }

        //    if (leftAdvPanel.Count > 0)
        //        ViewBag.LeftAdvPanel = leftAdvPanel.FirstOrDefault();
        //    if (rightAdvPanel.Count > 0)
        //        ViewBag.RightAdvPanel = rightAdvPanel.FirstOrDefault();
        //    return View(objENContent);
        //}

        public ActionResult Topic()
        {
            var objENContent = new enContent() { Type = (int)ContentType.DebateTopic };
            var objBLContent = new blContent(objENContent);
            try
            {
                objBLContent.Read();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.Topic() Error while Read() Content");
            }

            //Advertisement Panel
            var objENAdvertisement = new enAdvertisement() { Content_ID = (int)ContentType.DebateTopic };
            var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
            List<enAdvertisement> listOfAdvertisements = new List<enAdvertisement>();
            try
            {
                listOfAdvertisements = objBLAdvertisement.ReadAll();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.About() Error while Read() Advertisement  Exception:- " + ex.ToString());
            }

            List<enAdvertisement> leftAdvPanel = new List<enAdvertisement>();
            List<enAdvertisement> rightAdvPanel = new List<enAdvertisement>();
            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.LEFT))
            {
                if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        leftAdvPanel.Add(item);
                    }
                }
            }

            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.RIGHT))
            {
                if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        rightAdvPanel.Add(item);
                    }
                }
            }

            if (leftAdvPanel.Count > 0)
                ViewBag.LeftAdvPanel = leftAdvPanel.FirstOrDefault();
            if (rightAdvPanel.Count > 0)
                ViewBag.RightAdvPanel = rightAdvPanel.FirstOrDefault();

            return View(objENContent);
        }

        public ActionResult Winner()
        {
            var objENContent = new enContent() { Type = (int)ContentType.DebateWinner };
            var objBLContent = new blContent(objENContent);
            try
            {
                objBLContent.Read();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.Winner() Error while Read() Content");
            }

            //Advertisement Panel
            var objENAdvertisement = new enAdvertisement() { Content_ID = (int)ContentType.DebateWinner };
            var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
            List<enAdvertisement> listOfAdvertisements = new List<enAdvertisement>();
            try
            {
                listOfAdvertisements = objBLAdvertisement.ReadAll();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.About() Error while Read() Advertisement  Exception:- " + ex.ToString());
            }

            List<enAdvertisement> leftAdvPanel = new List<enAdvertisement>();
            List<enAdvertisement> rightAdvPanel = new List<enAdvertisement>();
            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.LEFT))
            {
                if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        leftAdvPanel.Add(item);
                    }
                }
            }

            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.RIGHT))
            {
                if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        rightAdvPanel.Add(item);
                    }
                }
            }

            if (leftAdvPanel.Count > 0)
                ViewBag.LeftAdvPanel = leftAdvPanel.FirstOrDefault();
            if (rightAdvPanel.Count > 0)
                ViewBag.RightAdvPanel = rightAdvPanel.FirstOrDefault();

            return View(objENContent);
        }

        public ActionResult Idea()
        {
            var objENContent = new enContent() { Type = (int)ContentType.InnovativeIdea };
            var objBLContent = new blContent(objENContent);
            try
            {
                objBLContent.Read();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.Idea() Error while Read() Content");
            }

            //Advertisement Panel
            var objENAdvertisement = new enAdvertisement() { Content_ID = (int)ContentType.InnovativeIdea };
            var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
            List<enAdvertisement> listOfAdvertisements = new List<enAdvertisement>();
            try
            {
                listOfAdvertisements = objBLAdvertisement.ReadAll();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.Content.About() Error while Read() Advertisement  Exception:- " + ex.ToString());
            }

            List<enAdvertisement> leftAdvPanel = new List<enAdvertisement>();
            List<enAdvertisement> rightAdvPanel = new List<enAdvertisement>();
            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.LEFT))
            {
                if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        leftAdvPanel.Add(item);
                    }
                }
            }

            foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.RIGHT))
            {
                if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
                {
                    if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
                    {
                        rightAdvPanel.Add(item);
                    }
                }
            }

            if (leftAdvPanel.Count > 0)
                ViewBag.LeftAdvPanel = leftAdvPanel.FirstOrDefault();
            if (rightAdvPanel.Count > 0)
                ViewBag.RightAdvPanel = rightAdvPanel.FirstOrDefault();

            return View(objENContent);
        }

        //public ActionResult Testimonial()
        //{
        //    var objENContent = new enContent() { Type = (int)ContentType.Testimonial };
        //    var objBLContent = new blContent(objENContent);
        //    try
        //    {
        //        objBLContent.Read();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("Hangout.UI.Content.Testimonial() Error while Read() Content");
        //    }

        //    //Advertisement Panel
        //    var objENAdvertisement = new enAdvertisement() { Content_ID = (int)ContentType.Testimonial };
        //    var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
        //    List<enAdvertisement> listOfAdvertisements = new List<enAdvertisement>();
        //    try
        //    {
        //        listOfAdvertisements = objBLAdvertisement.ReadAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("Hangout.UI.Content.About() Error while Read() Advertisement  Exception:- " + ex.ToString());
        //    }

        //    List<enAdvertisement> leftAdvPanel = new List<enAdvertisement>();
        //    List<enAdvertisement> rightAdvPanel = new List<enAdvertisement>();
        //    foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.LEFT))
        //    {
        //        if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
        //        {
        //            if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
        //            {
        //                leftAdvPanel.Add(item);
        //            }
        //        }
        //    }

        //    foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.RIGHT))
        //    {
        //        if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
        //        {
        //            if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
        //            {
        //                rightAdvPanel.Add(item);
        //            }
        //        }
        //    }

        //    if (leftAdvPanel.Count > 0)
        //        ViewBag.LeftAdvPanel = leftAdvPanel.FirstOrDefault();
        //    if (rightAdvPanel.Count > 0)
        //        ViewBag.RightAdvPanel = rightAdvPanel.FirstOrDefault();

        //    return View(objENContent);
        //}

        //public ActionResult Theme()
        //{
        //    var objENContent = new enContent() { Type = (int)ContentType.Theme };
        //    var objBLContent = new blContent(objENContent);
        //    try
        //    {
        //        objBLContent.Read();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("Hangout.UI.Content.Theme() Error while Read() Content");
        //    }

        //    //Advertisement Panel
        //    var objENAdvertisement = new enAdvertisement() { Content_ID = (int)ContentType.Theme };
        //    var objBLAdvertisement = new blAdvertisement(objENAdvertisement);
        //    List<enAdvertisement> listOfAdvertisements = new List<enAdvertisement>();
        //    try
        //    {
        //        listOfAdvertisements = objBLAdvertisement.ReadAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("Hangout.UI.Content.About() Error while Read() Advertisement  Exception:- " + ex.ToString());
        //    }

        //    List<enAdvertisement> leftAdvPanel = new List<enAdvertisement>();
        //    List<enAdvertisement> rightAdvPanel = new List<enAdvertisement>();
        //    foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.LEFT))
        //    {
        //        if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
        //        {
        //            if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
        //            {
        //                leftAdvPanel.Add(item);
        //            }
        //        }
        //    }

        //    foreach (var item in listOfAdvertisements.FindAll(x => x.Position == (int)PagePosition.RIGHT))
        //    {
        //        if (item.Date_To <= DateTime.Now && item.Date_From >= DateTime.Now)
        //        {
        //            if (item.Time_To <= DateTime.Now.TimeOfDay && item.Time_From >= DateTime.Now.TimeOfDay)
        //            {
        //                rightAdvPanel.Add(item);
        //            }
        //        }
        //    }

        //    if (leftAdvPanel.Count > 0)
        //        ViewBag.LeftAdvPanel = leftAdvPanel.FirstOrDefault();
        //    if (rightAdvPanel.Count > 0)
        //        ViewBag.RightAdvPanel = rightAdvPanel.FirstOrDefault();

        //    return View(objENContent);
        //}
    }
}