using System.Web.Optimization;

namespace MovieTickets.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.*",
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-timepicker.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery-validate").Include(
                "~/Scripts/jquery.validate-vsdoc.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/Scripts/modernizr").Include(
                "~/Scripts/modernizr-{version}.js"));

            bundles.Add(new ScriptBundle("~/Scripts/custom-place-organization").Include(
                "~/Scripts/places-organization.js",
                "~/Scripts/jquery.hallRender.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap-filestyle").Include(
                "~/Scripts/bootstrap-filestyle.js"));

            bundles.Add(new StyleBundle("~/Content/site").Include(
                "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/timepicker").Include(
                "~/Content/bootstrap-timepicker.css",
                "~/Content/bootstrap-responsive.css"));

            bundles.Add(new StyleBundle("~/Content/font-awesome").Include(
                "~/Content/font-awesome.css"));
        }
    }
}