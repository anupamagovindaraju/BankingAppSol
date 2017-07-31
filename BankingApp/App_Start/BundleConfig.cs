using System.Web;
using System.Web.Optimization;

namespace BankingApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                     "~/Scripts/sweetalert.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                     "~/Scripts/grid.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                   "~/Scripts/DataTables/jquery.dataTables.min.js",
                   "~/Scripts/DataTables/jquery.jeditable.js",
                    "~/Scripts/DataTables/jquery-ui.js",
                   "~/Scripts/DataTables/jquery.dataTables.editable.js",
                   "~/Scripts/mindmup-editabletable.js"
                   ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/sweetalert.css",
                      "~/Content/site.css"));
        }
    }
}
