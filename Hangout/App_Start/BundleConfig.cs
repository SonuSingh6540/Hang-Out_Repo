using System.Web.Optimization;

namespace Hangout
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/basescripts").Include(
                    "~/CDN/Content/Scripts/jQuery-2.1.4.min.js",
                    "~/CDN/Content/Scripts/compressed.js",
                    "~/CDN/Content/Scripts/main.js",
                    "~/CDN/Content/Scripts/moment.min.js",
                    "~/CDN/Content/Scripts/fullcalendar.min.js",
                    "~/CDN/Content/Scripts/daterangepicker.js",
                    "~/CDN/Content/Scripts/Chart.bundle.min.js",
                    "~/CDN/Content/Scripts/jquery-jvectormap-2.0.3.min.js",
                    "~/CDN/Content/Scripts/jquery-jvectormap-world-mill.js",
                    "~/CDN/Content/Scripts/modernizr-2.6.2.min.js",
                    "~/CDN/Content/Scripts/jquery.sparkline.min.js",
                    "~/CDN/Content/Scripts/jquery.dataTables.min.js",
                    "~/CDN/Content/Scripts/admin.js"
                        ));
            
            bundles.Add(new StyleBundle("~/bundles/basestyles").Include(
                     "~/CDN/Content/Css/bootstrap.min.css",
                     "~/CDN/Content/Css/style.css",
                     "~/CDN/Content/Css/animations.css",
                     "~/CDN/Content/Css/fonts.css",
                     "~/CDN/Content/Css/dashboard.css",
                     "~/CDN/Content/Css/main.css"
                        ));
        }
    }
}