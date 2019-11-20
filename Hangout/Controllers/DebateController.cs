using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BusinessLogicLayer;
using MoreLinq;

namespace Hangout.Controllers
{
    public class DebateController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(enDebate enDebate_)
        {
            var objBLDebate = new blDebate(enDebate_);
            enDebate_.IsActive = true;
            try
            {
                objBLDebate.Create();
            }
            catch (Exception ex)
            {
                return RedirectToAction("error", "misc");
            }
            return RedirectToAction("list");
        }

        public ActionResult List()
        {
            var objENDebate = new enDebate();
            var objBLDebate = new blDebate(objENDebate);
            List<enDebate> listOfDebates = new List<enDebate>();
            try
            {
                listOfDebates = objBLDebate.ReadAllAndAggregate(null, null, typeof(enCategory));
            }
            catch
            {
                return RedirectToAction("error", "misc");
            }

            return View(listOfDebates);
        }
        
        public ActionResult Update(int id)
        {
            var objENDebate = new enDebate() { ID = id };
            var objBLDebate = new blDebate(objENDebate);
            try
            {
                objBLDebate.Read();
            }
            catch
            {
                return RedirectToAction("error","misc");
            }
            return View("create", objENDebate);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(int id,enDebate enDebate_)
        {
            var objENDebate = new enDebate() { ID = id };
            var objBLDebate = new blDebate(objENDebate);
            try
            {
                objBLDebate.Read();
            }
            catch
            {
                return RedirectToAction("error", "misc");
            }

            enDebate_.InsertedOn = objENDebate.InsertedOn;
            objBLDebate = new blDebate(enDebate_);
            try
            {
                objBLDebate.Update();
            }
            catch 
            {
                return RedirectToAction("error", "misc");
            }
            return RedirectToAction("list");
        }

        public ActionResult Delete(int id)
        {
            var objENDebate = new enDebate() { ID = id};
            var objBLDebate = new blDebate(objENDebate);
            try
            {
                objBLDebate.Delete();
            }
            catch
            {
                return RedirectToAction("error","misc");
            }
            return RedirectToAction("list");
        }
        
        public ActionResult IsActive(int id)
        {
            var objENDebate = new enDebate() { ID = id };
            var objBLDebate = new blDebate(objENDebate);
            try
            {
                objBLDebate.Read();
            }
            catch
            {
                return RedirectToAction("error", "misc");
            }

            objENDebate.IsActive = false;
            objBLDebate = new blDebate(objENDebate);
            try
            {
                objBLDebate.Update();
            }
            catch
            {
                return RedirectToAction("error", "misc");
            }

            return RedirectToAction("create");
        }

        public ActionResult getParticepent(int debateID)
        {
            var objENComment = new enComment() { Debate_ID = debateID };
            var objBLComment = new blComment(objENComment);
            List<enComment> listOfComments = new List<enComment>();
            try
            {
                listOfComments = objBLComment.ReadAllAndAggregate(null, null, typeof(enDebate), typeof(enUser));
            }
            catch
            {
                return RedirectToAction("error", "misc");
            }

            listOfComments = listOfComments.DistinctBy(x => x.User_ID).ToList();
            foreach (var item in listOfComments)
            {
                var objENLikeCounter = new enLikeCounter() { User_ID = item.User_ID, Debate_ID = item.Debate_ID };
                var objBLLikeCounter = new blLikeCounter(objENLikeCounter);
                List<enLikeCounter> listOfLikesCounters = new List<enLikeCounter>();
                try
                {
                    listOfLikesCounters = objBLLikeCounter.ReadAll();
                    item.LikesCount = listOfLikesCounters.Count();
                }
                catch
                {
                    return RedirectToAction("error", "misc");
                }
            }
            return Json(listOfComments, JsonRequestBehavior.AllowGet);
        }
    }
}