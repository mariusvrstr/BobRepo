using Microsoft.Web.Optimization;

namespace JBOB.Web.App_Start
{
    using System.Web.Optimization;

    /// <summary>
    /// Contains the bundle details
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registers the bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            // We want JQuery to load seperate and first
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-1.9.1.js"));

            bundles.Add(new ScriptBundle("~/Scripts/app_common").Include(
                "~/Scripts/jquery.dataTables.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/common.js",
                "~/Scripts/Scrolling.js"));

            bundles.Add(new StyleBundle("~/Content/common_css").Include(
               "~/Content/bootstrap/bootstrap.css",
                "~/Content/site.css",
                "~/Content/jquery.dataTables.css" ));
        }
    }
}