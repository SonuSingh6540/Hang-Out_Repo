using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BusinessLogicLayer;

namespace Hangout.Controllers
{
    public class ContestController : Controller
    {
        // GET: Contest
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(enContest enContest)
        {
            var objBLContest = new blContest(enContest);
            try
            {
                objBLContest.Create();
            }
            catch (Exception ex)
            {
                return RedirectToAction("error", "misc");
            }
            return RedirectToAction("list");
        }

        public ActionResult List()
        {
            var objENContest = new enContest();
            var objBLContest = new blContest(objENContest);
            List<enContest> listOfContests = new List<enContest>();
            try
            {
                listOfContests = objBLContest.ReadAll();
            }
            catch(Exception ex)
            {
                return View("error", "misc");
            }
            return View(listOfContests);
        }

        public ActionResult Update(int id)
        {
            var objENContest = new enContest() { ID = id };
            var objBLContest = new blContest(objENContest);
            List<enContest> listOfContests = new List<enContest>();
            try
            {
                objBLContest.Read();
            }
            catch
            {
                RedirectToAction("error", "misc");
            }
            return View("create", objENContest);
        }

        [HttpPost]
        public ActionResult Update(int id, enContest enContest_)
        {
            var objENContest = new enContest() { ID = id };
            var objBLContest = new blContest(objENContest);
            try
            {
                objBLContest.Read();
            }
            catch
            {
                RedirectToAction("error", "misc");
            }

            enContest_.InsertedOn = objENContest.InsertedOn;
            objBLContest = new blContest(enContest_);
            try
            {
                objBLContest.Update();
            }
            catch
            {
                RedirectToAction("error", "misc");
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var objENContest = new enContest() { ID = id };
            var objBLContest = new blContest(objENContest);
            try
            {
                objBLContest.Delete();
            }
            catch
            {
                return RedirectToAction("error", "misc");
            }
            return RedirectToAction("list");
        }

        public ActionResult GetContestStatus(int id)
        {
            var objENContestStatus = new enContestStatus() { ContestID = id};
            var objBLContestStatus = new blContestStatus(objENContestStatus);
            List<enContestStatus> listOfContestStatus = new List<enContestStatus>();
            try
            {
                listOfContestStatus = objBLContestStatus.ReadAllAndAggregate(typeof(enContest),typeof(enUser));
            }
            catch (Exception ex)
            {
                return RedirectToAction("error","misc");
            }

            return View(listOfContestStatus);
        }
    }
}