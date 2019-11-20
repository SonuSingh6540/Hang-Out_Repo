using System.Web.Optimization;

namespace UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {   
            bundles.Add(new ScriptBundle("~/bundles/basescripts").Include(
                    "~/CDN/Content/Scripts/Jquery.js",
                    "~/CDN/Content/Scripts/jquery.nav.js",
                    "~/CDN/Content/Scripts/flexslider-min.js",
                    "~/CDN/Content/Scripts/plugins.js",
                    "~/CDN/Content/Scripts/isotope.pkgd.min.js",
                    "~/CDN/Content/Scripts/gmaps.js",
                    "~/CDN/Content/Scripts/progressbar.min.js",
                    "~/CDN/Content/Scripts/functions.js"
                        ));

            bundles.Add(new StyleBundle("~/bundles/basestyles").Include(
                    "~/CDN/Content/Css/style.css",
                    "~/CDN/Content/Css/flexslider.css",
                    "~/CDN/Content/Css/bootstrap.css",
                    "~/CDN/Content/Css/animations.css",
                    "~/CDN/Content/Css/magnific-popup.css",
                    "~/CDN/Content/Css/icon-fonts.css"
                  ));
        }
    }
}