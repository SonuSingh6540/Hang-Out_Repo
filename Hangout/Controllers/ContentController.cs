using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BusinessLogicLayer;

namespace Hangout.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Create()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(enContent enContent_)
        {
            var objENContent = new enContent() { Type = enContent_.Type };
            var objBLContent = new blContent(objENContent);
            try
            {
                objBLContent.Read();
            }
            catch (Exception ex)
            {
                
            }

            if (objENContent.ID > 0)
            {
                objBLContent = new blContent(enContent_);
                enContent_.ID = objENContent.ID;
                enContent_.InsertedOn = objENContent.InsertedOn;
                try
                {
                    objBLContent.Update();
                }
                catch (Exception ex)
                {
                }
            }

            else
            {
                objBLContent = new blContent(enContent_);
                try
                {
                    objBLContent.Create();
                }
                catch (Exception ex)
                {

                }
            }

            ViewBag.typeID = enContent_.Type;
            return View();
        }

        public JsonResult GetDescription(int typeID)
        {
            var objENContent = new enContent() { Type = typeID };
            var objBLContent = new blContent(objENContent);
            try
            {
                objBLContent.Read();
            }
            catch (Exception ex)
            {

            }
            return Json(objENContent, JsonRequestBehavior.AllowGet);
        }
    }
}