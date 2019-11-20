using BusinessLogicLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;


namespace UIHelper
{
    public class CollectionsHelper
    {
        public static IEnumerable<SelectListItem> IEnumerableSupportedLanguages(SelectListItem itemToAddAtTop_ = null)
        {
            var supportedLanguagesList = new List<SelectListItem>();
            SelectListItem english_IN = new SelectListItem { Value = "en-IN", Text = "English (India)", Selected = true };
            SelectListItem hindi_IN = new SelectListItem { Value = "hi-IN", Text = "Hindi (India)" };
            supportedLanguagesList.Add(english_IN);
            supportedLanguagesList.Add(hindi_IN);
            return supportedLanguagesList.AsEnumerable<SelectListItem>();
        }

        //public static IEnumerable<SelectListItem> IEnumerableSubjectListItem(int? classID)
        //{
        //    List<enSubject> listOfSubjects = new List<enSubject>();
        //    List<SelectListItem> result = new List<SelectListItem>();
        //    if (classID > 0)
        //    {
        //        var objBLSubject = new blSubject(new enSubject { Class_ID = classID.Value });
        //        listOfSubjects = objBLSubject.ReadAll();
        //        listOfSubjects = listOfSubjects.FindAll(x => x.Is_Active == Convert.ToBoolean((int)IsActive.TRUE));

        //        if (listOfSubjects != null)
        //        {
        //            result.AddRange(
        //                from item in listOfSubjects
        //                select new SelectListItem { Text = item.Subject_Name, Value = item.ID.ToString(), Selected = true });
        //            return result.AsEnumerable();
        //        }
        //    }

        //    return result.AsEnumerable();
        //}

        public static IEnumerable<SelectListItem> IEnumerableEmptyListItem()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            result.Add(new SelectListItem { Text = "--select--", Value = 1.ToString() });
            return result.AsEnumerable();
        }

        public static IEnumerable<SelectListItem> IEnumerableCategoryListItem(int? categoryID)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            List<enCategory> listOfTopics = new List<enCategory>();

            var objBLTopic = new blCategory(new enCategory { ID = categoryID.Value });
            listOfTopics = objBLTopic.ReadAll();
            listOfTopics = listOfTopics.FindAll(x => x.IsActive == Convert.ToBoolean((int)IsActive.TRUE));
            if (listOfTopics != null)
            {
                result.AddRange(
                    from item in listOfTopics
                    select new SelectListItem { Text = Helper.StripHTMLAndRemoveSymbols(item.Name) , Value = item.ID.ToString()});
                return result.AsEnumerable();
            }

            return result.AsEnumerable();
        }

        public static IEnumerable<SelectListItem> IEnumerableContentPage()
        {
            var enumData = from ContentType e in Enum.GetValues(typeof(ContentType))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            List<SelectListItem> result = new List<SelectListItem>();
            result.Add(new SelectListItem { Text = "Select Content Type", Value = "" });
            foreach (var item in enumData)
            {
                result.Add(new SelectListItem { Text = item.Name, Value = item.ID.ToString() });
            }

            return result;
        }

        public static IEnumerable<SelectListItem> IEnumerableCountryCode()
        {
            var enumData = from CountryCode e in Enum.GetValues(typeof(CountryCode))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            List<SelectListItem> result = new List<SelectListItem>();
            result.Add(new SelectListItem { Text = "-- Select Country --", Value = "" });
            foreach (var item in enumData)
            {
                result.Add(new SelectListItem { Text = item.Name, Value = item.ID.ToString() });
            }

            return result.OrderBy(x =>x.Text);
        }

        public static IEnumerable<SelectListItem> IEnumerablePagePosition()
        {
            var enumData = from PagePosition e in Enum.GetValues(typeof(PagePosition))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            List<SelectListItem> result = new List<SelectListItem>();
            result.Add(new SelectListItem { Text = "Select Position", Value = "" });
            foreach (var item in enumData)
            {
                result.Add(new SelectListItem { Text = item.Name, Value = item.ID.ToString() });
            }
            return result;
        }

        public static IEnumerable<SelectListItem> IEnumerableIdeaAndTopic()
        {
            var enumData = from IdeaAndTopic e in Enum.GetValues(typeof(IdeaAndTopic))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (var item in enumData)
            {
                result.Add(new SelectListItem { Text = item.Name, Value = item.ID.ToString() });
            }

            return result;
        }

        public static IEnumerable<SelectListItem> IEnumerableContactUsSubject()
        {
            var supportedLanguagesList = new List<SelectListItem>();
            SelectListItem english_IN = new SelectListItem { Value = "1", Text = "Debate Topic"};
            SelectListItem hindi_IN = new SelectListItem { Value = "2", Text = "Add Member" };
            SelectListItem Innovative_Idea = new SelectListItem { Value = "3", Text = "Innovative Idea" };
            SelectListItem Other = new SelectListItem { Value = "4", Text = "Other" };
            supportedLanguagesList.Add(english_IN);
            supportedLanguagesList.Add(hindi_IN);
            supportedLanguagesList.Add(Innovative_Idea);
            supportedLanguagesList.Add(Other);
            return supportedLanguagesList.AsEnumerable<SelectListItem>();
        }
    }
}