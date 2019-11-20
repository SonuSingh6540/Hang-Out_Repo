using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web.Mvc;

namespace UIHelper
{
    public static class ExtensionMethods
    {
        public static MvcHtmlString EnumToString<T>(this HtmlHelper helper)
        {
            var values = Enum.GetValues(typeof(T)).Cast<int>();
            var enumDictionary = values.ToDictionary(value => Enum.GetName(typeof(T), value));

            return new MvcHtmlString(JsonConvert.SerializeObject(enumDictionary));
        }
    }
}