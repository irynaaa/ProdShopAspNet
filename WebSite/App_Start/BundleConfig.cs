using System.Web;
using System.Web.Optimization;

namespace WebSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                 "~/AdminContent/bower_components/jquery/dist/jquery.min.js",
                 "~/AdminContent/bower_components/bootstrap/dist/js/bootstrap.min.js",
                       "~/AdminContent/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/AdminContent/bower_components/fastclick/lib/fastclick.js",
                         "~/AdminContent/dist/js/adminlte.min.js",
                          "~/AdminContent/dist/js/demo.js",
                           "~/Scripts/bootstrap.js",
                           "~/Scripts/respond.js")
                      );

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap-lumen.css",
                      "~/AdminContent/bower_components/bootstrap/dist/css/bootstrap.min.css",
                      "~/AdminContent/bower_components/font-awesome/css/font-awesome.min.css",
                      "~/AdminContent/bower_components/Ionicons/css/ionicons.min.css",
                      "~/AdminContent/dist/css/AdminLTE.min.css",
                      "~/AdminContent/dist/css/skins/_all-skins.min.css",
                      "~/Content/Site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
