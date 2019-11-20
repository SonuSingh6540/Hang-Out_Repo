using Entity;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MoreLinq;
using Utility;

namespace UI.Controllers
{
    public class DebateController : BaseController
    {
        public ActionResult Category()
        {
            var objENCategory = new enCategory();
            var objBLCategory = new blCategory(objENCategory);
            List<enCategory> listOfCategories = new List<enCategory>();
            try
            {
                listOfCategories = objBLCategory.ReadAll();
            }
            catch (Exception ex)
            {
                Log.Error("HangOut.UI.DebateController.Category() Error while Read Category()  Exception:-" + ex.ToString());
            }
            return View(listOfCategories);
        }

        public ActionResult Index(int id)
        {
            #region Category
            var objENCategory = new enCategory() { ID = id };
            var objBLCategory = new blCategory(objENCategory);
            try
            {
                objBLCategory.Read();
            }
            catch (Exception ex)
            {
                throw;
            }
            ViewBag.Title = objENCategory.Name;
            #endregion

            var objENDebate = new enDebate() { Category_ID = id };
            var objBLDebate = new blDebate(objENDebate);
            List<enDebate> listOfDebates = new List<enDebate>();
            try
            {
                listOfDebates = objBLDebate.ReadAllAndAggregate(null, null, typeof(enUser));
            }
            catch (Exception ex)
            {
                Log.Error("Hang-Out.UI.DebateController.Index() Error while Read() Debate  Exception:- " + ex.ToString());
            }

            foreach (var item in listOfDebates)
            {
                if (item.Date.Date < DateTime.Now.Date)
                {
                    if (item.IsActive != false)
                    {
                        var objENLikeCounter = new enLikeCounter() { Debate_ID = item.ID };
                        var objBLLikeCounter = new blLikeCounter(objENLikeCounter);
                        List<enLikeCounter> listOfLikesCounter = new List<enLikeCounter>();
                        try
                        {
                            listOfLikesCounter = objBLLikeCounter.ReadAll();
                            if (listOfLikesCounter.Count > 0)
                            {
                                var maxRepeated = listOfLikesCounter.GroupBy(s => s.User_ID).OrderByDescending(s => s.Count()).First().Key;
                                int count = listOfLikesCounter.FindAll(x => x.User_ID == Convert.ToInt32(maxRepeated)).Count;
                                if (Convert.ToInt32(count) > 0)
                                {
                                    var objENReward = new enReward();
                                    objENReward.Point = 50;
                                    objENReward.Type = (int)RewardType.WINNER;
                                    objENReward.User_ID = Convert.ToInt32(maxRepeated);
                                    var objBLReward = new blReward(objENReward);
                                    try
                                    {
                                        objBLReward.Create();
                                    }
                                    catch (Exception ex)
                                    {
                                        Log.Error("Hang-Out.UI.DebateController.Index() Error while Create() Reward  Exception:-" + ex.ToString());
                                        return RedirectToAction("error", "misc");
                                    }

                                    item.IsActive = false;
                                    item.LikesCount = count;
                                    item.User_ID = maxRepeated;
                                    objBLDebate = new blDebate(item);
                                    try
                                    {
                                        objBLDebate.Update();
                                    }
                                    catch (Exception ex)
                                    {
                                        Log.Error("Hang-Out.UI.DebateController.Index() Error while Update() Debate  Exception:-" + ex.ToString());
                                        return RedirectToAction("error", "misc");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Hang-Out.UI.DebateController.Index() Error while Read() LikeCounter  Exception:-" + ex.ToString());
                            return RedirectToAction("error", "misc");
                        }
                    }
                }
                else if (item.Date.Date == DateTime.Now.Date)
                {
                    if (item.Start <= DateTime.Now.TimeOfDay && item.End >= DateTime.Now.TimeOfDay)
                    {
                        item.IsActive = true;
                    }
                    else if (item.Start <= DateTime.Now.TimeOfDay && item.End <= DateTime.Now.TimeOfDay)
                    {
                        if (item.IsActive != false)
                        {
                            item.IsActive = false;
                            var objENLikeCounter = new enLikeCounter() { Debate_ID = item.ID };
                            var objBLLikeCounter = new blLikeCounter(objENLikeCounter);
                            List<enLikeCounter> listOfLikesCounter = new List<enLikeCounter>();
                            try
                            {
                                listOfLikesCounter = objBLLikeCounter.ReadAll();
                                if (listOfLikesCounter.Count > 0)
                                {
                                    var maxRepeated = listOfLikesCounter.GroupBy(s => s.User_ID).OrderByDescending(s => s.Count()).First().Key;
                                    int count = listOfLikesCounter.FindAll(x => x.User_ID == Convert.ToInt32(maxRepeated)).Count;
                                    if (Convert.ToInt32(count) > 0)
                                    {
                                        var objENReward = new enReward();
                                        objENReward.Point = 50;
                                        objENReward.Type = (int)RewardType.WINNER;
                                        objENReward.User_ID = Convert.ToInt32(maxRepeated);
                                        var objBLReward = new blReward(objENReward);
                                        try
                                        {
                                            objBLReward.Create();
                                        }
                                        catch (Exception ex)
                                        {
                                            Log.Error("Hang-Out.UI.DebateController.Index() Error while Create() Reward  Exception:-" + ex.ToString());
                                            return RedirectToAction("error", "misc");
                                        }
                                        item.LikesCount = count;
                                        item.User_ID = maxRepeated;
                                        objBLDebate = new blDebate(item);
                                        try
                                        {
                                            objBLDebate.Update();
                                        }
                                        catch (Exception ex)
                                        {
                                            Log.Error("Hang-Out.UI.DebateController.Index() Error while Update() Debate  Exception:-" + ex.ToString());
                                            return RedirectToAction("error", "misc");
                                        }
                                    }
                                }
                                else
                                {
                                    objBLDebate = new blDebate(item);
                                    try
                                    {
                                        objBLDebate.Update();
                                    }
                                    catch (Exception ex)
                                    {
                                        Log.Error("Hangout.UI.DebateControl.Index() error while Update() Debate Exception:-" + ex.ToString());
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Log.Error("Hang-Out.UI.DebateController.Index() Error while Read() LikeCounter  Exception:-" + ex.ToString());
                                return RedirectToAction("error", "misc");
                            }
                        }
                    }
                    else
                    {
                        item.IsActive = false;
                    }
                }
                else
                {
                    item.IsActive = false;
                }
            }
            return View(listOfDebates);
        }

        public ActionResult DebateRoom(int debateID)
        {
            var objENDebate = new enDebate() { ID = debateID };
            var objBLDebate = new blDebate(objENDebate);
            try
            {
                objBLDebate.Read();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.DebateController.DebateRoom() Error while Read() Debate  Exception:-" + ex.ToString());
            }
            ViewBag.DebateTopic = objENDebate.Topic;
            ViewBag.DebateDescription = objENDebate.Description;

            var objENComment = new enComment() { Debate_ID = debateID };
            var objBLComment = new blComment(objENComment);
            List<enComment> listOfComments = new List<enComment>();
            try
            {
                listOfComments = objBLComment.ReadAllAndAggregate(null, null, typeof(enUser), typeof(enLikeCounter));
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.DebateController.DebateRoom() Error while Read() Comment  Exception:-" + ex.ToString());
            }

            if (listOfComments.Count > 0)
            {
                List<enComment> listOfDistinctID = listOfComments.DistinctBy(x => x.User_ID).ToList();
                ViewBag.DistinctID = listOfDistinctID;
            }
            var objCommentModel = new CommentModel();
            objCommentModel.listOfComments = listOfComments.OrderBy(x => x.ID).ToList();


            ViewBag.ForListOfComments = listOfComments.FindAll(x => x.Type == (int)CommentType.FOR).OrderBy(x => x.InsertedOn);
            ViewBag.AgainstListOfComments = listOfComments.FindAll(x => x.Type == (int)CommentType.AGAINST).OrderBy(x => x.InsertedOn);

            objCommentModel.Comments_ = objENComment;
            ViewBag.UserID = CookieDetail.UserID;

            var objENDebateAdvertisement = new enDebateAdvertisement() { GetByDate = 1};
            var objBLDebateAdvertisement = new blDebateAdvertisement(objENDebateAdvertisement);
            List<enDebateAdvertisement> listOfDebaetAdvertisements = new List<enDebateAdvertisement>();
            try
            {
                listOfDebaetAdvertisements = objBLDebateAdvertisement.ReadAllAndAggregate(typeof(enDebateAdvertisementImage));
            }
            catch (Exception ex)
            {

            }

            var count = listOfDebaetAdvertisements.FirstOrDefault().ListOfDebateAdvertisementImage_.Count;
             if(count > 0)
            {
                var half = count / 2;
                var secondlistIndex = count - half;
                ViewBag.LeftDebateAdvertisementImage = listOfDebaetAdvertisements.FirstOrDefault().ListOfDebateAdvertisementImage_.GetRange(0, half);
                ViewBag.RightDebateAdvertisementImage = listOfDebaetAdvertisements.FirstOrDefault().ListOfDebateAdvertisementImage_.GetRange(half, secondlistIndex);
            }



            return View(objCommentModel);
        }

        [HttpPost]
        public ActionResult Comment(CommentModel CommentModel_)
        {
            CommentModel_.Comments_.User_ID = CookieDetail.UserID;
            var objBLComment = new blComment(CommentModel_.Comments_);
            try
            {
                objBLComment.Create();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.DebateController.Comment() Error while Create() Comment  Exception:-" + ex.ToString());
            }
            return RedirectToAction("debateroom", new { debateID = CommentModel_.Comments_.Debate_ID });
        }

        public JsonResult ajaxComment(int debID, int type, string msg)
        {
            var objENComment = new enComment();
            objENComment.User_ID = CookieDetail.UserID;
            objENComment.Debate_ID = debID;
            objENComment.Type = type;
            objENComment.Message = msg;
            var objBLComment = new blComment(objENComment);
            try
            {
                objBLComment.Create();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.DebateController.Comment() Error while Create() Comment  Exception:-" + ex.ToString());
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            objENComment = new enComment() { User_ID = (int)Session["User_ID"] };
            objBLComment = new blComment(objENComment);
            List<enComment> listOfComments = new List<enComment>();
            try
            {
                listOfComments = objBLComment.ReadAll();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.DebateController.Comment() Error while Read() Comment  Exception:-" + ex.ToString());
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            listOfComments = listOfComments.FindAll(x => x.Debate_ID == debID && x.Type == type);
            return Json(listOfComments, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DebateLike(int commentID, int userID, int debateID, int type)
        {
            var objENLikeCounter = new enLikeCounter() { Debate_ID = debateID, User_ID = userID, Comment_ID = commentID, Type = type };
            var objBLLikeCounter = new blLikeCounter(objENLikeCounter);
            try
            {
                objBLLikeCounter.Read();
            }
            catch (Exception ex)
            {
                Log.Error("Hangout.UI.DebateController.DebateLike() Error while Create() LikeCounter" + ex.ToString());
                return Json("Failure", JsonRequestBehavior.AllowGet);
            }

            if (objENLikeCounter.ID == 0)
            {
                objENLikeCounter = new enLikeCounter() { Debate_ID = debateID, User_ID = userID, Comment_ID = commentID, Type = type };
                objBLLikeCounter = new blLikeCounter(objENLikeCounter);
                try
                {
                    objBLLikeCounter.Create();
                }
                catch (Exception ex)
                {
                    Log.Error("Hangout.UI.DebateController.DebateLike() Error while Create() LikeCounter" + ex.ToString());
                    return Json("Failure", JsonRequestBehavior.AllowGet);
                }
            }
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}