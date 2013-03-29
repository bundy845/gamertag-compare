using System.Web.Optimization;

namespace Site.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.tablesorter.min.js",
                "~/Scripts/bootstrap-tabs.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}