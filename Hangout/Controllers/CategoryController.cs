using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.IO;
using Entity;
using BusinessLogicLayer;
using Utility;

namespace Hangout.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Create()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(enCategory enCategory_)
        {
            if (enCategory_.file != null)
            {
                enCategory_.Image_Name = Helper.GetRandomAlphaNumericSMSToken() + "-" + Path.GetFileName(enCategory_.file.FileName);
                try
                {
                    var path = Path.Combine(Server.MapPath(Helper.CategoryImagePath()) + enCategory_.Image_Name);
                    bool exist = Directory.Exists(Server.MapPath(Helper.CategoryImagePath()));
                    if (!exist)
                        Directory.CreateDirectory(Server.MapPath(Helper.CategoryImagePath()));
                    enCategory_.file.SaveAs(path);
                }
                catch (Exception ex)
                {
                    return RedirectToAction("error", "misc");
                }
            }

            var objBLCategory = new blCategory(enCategory_);
            try
            {
                objBLCategory.Create();
            }
            catch (Exception ex)
            {
                return RedirectToAction("error", "misc");
            }

            return RedirectToAction("list");
        }

        public ActionResult List()
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
                return RedirectToAction("error", "misc");
            }

            ViewBag.listOfCategories = listOfCategories;
            return View(listOfCategories);
        }

        public ActionResult Update(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("error", "misc");
            }

            var objENCategory = new enCategory { ID = id };
            var objBLCategory = new blCategory(objENCategory);
            try
            {
                objBLCategory.Read();
            }
            catch (Exception ex)
            {
                RedirectToAction("error", "misc");
            }

            return View("create", objENCategory);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(int id, enCategory enCategory_)
        {
            var objENCategory = new enCategory { ID = id };
            var objBLCategory = new blCategory(objENCategory);
            try
            {
                objBLCategory.Read();
            }
            catch
            {
                RedirectToAction("error", "misc");
            }

            if (enCategory_.file != null)
            {
                enCategory_.Image_Name = Helper.GetRandomAlphaNumericSMSToken() + "-" + Path.GetFileName(enCategory_.file.FileName);
                try
                {
                    var path = Path.Combine(Server.MapPath(Helper.CategoryImagePath()) + enCategory_.Image_Name);
                    bool exist = Directory.Exists(Server.MapPath(Helper.CategoryImagePath()));
                    if (!exist)
                        Directory.CreateDirectory(Server.MapPath(Helper.CategoryImagePath()));
                    enCategory_.file.SaveAs(path);
                }
                catch (Exception ex)
                {
                    return RedirectToAction("error", "misc");
                }

                enCategory_.InsertedOn = objENCategory.InsertedOn;
                objBLCategory = new blCategory(enCategory_);
                try
                {
                    objBLCategory.Update();
                }
                catch
                {
                    RedirectToAction("error", "misc");
                }
            }
            return RedirectToAction("list");
        }

        public ActionResult Delete(int id)
        {
            var objENCategory = new enCategory() { ID = id };
            var objBLCategory = new blCategory(objENCategory);

            try
            {
                objBLCategory.Delete();
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("list");
        }
    }
}