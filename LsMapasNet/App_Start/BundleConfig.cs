using System.Web;
using System.Web.Optimization;

namespace LsMapasNet
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jqueryui/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/materializejs").Include(
                      "~/Scripts/materializejs/js/materialize.js", "~/Scripts/materializejs/js/iniciamaterialize.js"));

            bundles.Add(new ScriptBundle("~/bundles/materializeselect").Include(
                      "~/Scripts/materializejs/js/materializeselect.js"));


            bundles.Add(new ScriptBundle("~/bundles/lsmapasjs").Include(
                      "~/Scripts/lsmapasjs/incluirmapa.js"));

            bundles.Add(new ScriptBundle("~/bundles/easycomplete").Include(
                      "~/Scripts/easycomplete/easy-autocomplete.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/jquery-ui.css",
            //          "~/Content/jquery-ui.theme.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/materializecss").Include(
                      "~/Content/materializecss/materialize.css"));

            bundles.Add(new StyleBundle("~/Content/easycomplete/css").Include(
                      "~/Content/easycomplete/easy-autocomplete.css", "~/Content/easycomplete/easy-autocomplete.themes.css"));
        }
    }
}
